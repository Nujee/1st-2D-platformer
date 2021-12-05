using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class FinishController : IDisposable
    {
        private LevelObjectView _playerView;
        private LevelObjectView _finishView;

        public FinishController(LevelObjectView playerView, LevelObjectView finishView)
        {
            _playerView = playerView;
            _finishView = finishView;

            _playerView.OnLevelObjectContact += Finish;
        }

        private void Finish(LevelObjectView contactView)
        {
            if (contactView == _finishView)
            {
                Debug.Log("Finish!");
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= Finish;
        }
    }
}