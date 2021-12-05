using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class DeathlyPitsController : IDisposable
    {
        // еще нужно занулить скорость и сделать rightscale игрока при попадании в яму, но пока что так :)
        // и вообще обобщить с deathlyPit на deathlyZone (вдруг опасные потолки будут или стены)

        private LevelObjectView _playerView;
        private List<LevelObjectView> _deathlyPitsView;
        private Vector3 _initialPlayerPosition;

        public DeathlyPitsController(LevelObjectView playerView, Vector3 initialPlayerPosition, List<LevelObjectView> deathlyPitsView)
        {
            
            _playerView = playerView;
            _deathlyPitsView = deathlyPitsView;
            _initialPlayerPosition = initialPlayerPosition;

            _playerView.OnLevelObjectContact += Kill;
        }

        private void Kill(LevelObjectView contactView)
        {
            if(_deathlyPitsView.Contains(contactView))
            {
                _playerView.transform.position = _initialPlayerPosition;
                Debug.Log("Death!");
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= Kill;
        }
    }
}