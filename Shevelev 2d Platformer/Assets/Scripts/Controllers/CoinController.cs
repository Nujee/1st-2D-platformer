using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CoinController : IDisposable
    {
        private LevelObjectView _playerView;
        private List<LevelObjectView> _coinsView;
        private SpriteAnimatorController _coinAnimator;
        private const float _animationSpeed = 10f;

        public CoinController(LevelObjectView playerView, List<LevelObjectView> coinsView, SpriteAnimatorController coinAnimator)
        {
            _playerView = playerView;
            _coinsView = coinsView;
            _coinAnimator = coinAnimator;

            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (LevelObjectView coinView in _coinsView)
            {
                _coinAnimator.StartAnimation(coinView._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinsView.Contains(contactView))
            {
                _coinAnimator.StopAnimation(contactView._spriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
