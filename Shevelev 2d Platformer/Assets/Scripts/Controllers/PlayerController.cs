using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    public class PlayerController
    {
        private float _xAxisInput;
        private bool _isJump;
        private bool _isMoving;
        private bool _isHighKick;

        private float _speed = 250f;
        private float _animationSpeed = 10f;
        private float _jumpSpeed = 9f;
        private float _movingThreshold = 0.1f;
        private float _jumpThreshold = 1f;

        private float _yVelocity;
        private float _xVelocity;
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private LevelObjectView _view;
        private SpriteAnimatorController _spriteAnimator;
        private readonly ContactPooler _contactPooler;

        public PlayerController(LevelObjectView player, SpriteAnimatorController animator)
        {
            _view = player;
            _spriteAnimator = animator;
            _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            _contactPooler = new ContactPooler(_view._collider);
        }

        private void MoveTowards()
        {
            _xVelocity = _speed * Time.fixedDeltaTime * (_xAxisInput < 0 ? -1 : 1);
            _view._rigidbody.velocity = _view._rigidbody.velocity.Change(x:_xVelocity);
            _view.transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);

        }

        private void Jump()
        {
            if (_isJump && Mathf.Abs(_view._rigidbody.velocity.y) <= _jumpThreshold)
            {
                _view._rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
        }

        public void Update()
        {
            _spriteAnimator.Update();
            _contactPooler.Update();
            _xAxisInput = Input.GetAxis("Horizontal");

            _isMoving = Mathf.Abs(_xAxisInput) > _movingThreshold;
            _isJump = Input.GetAxis("Vertical") > 0;
            _isHighKick = Input.GetAxis("Vertical") < 0;

            if (_isMoving)
            {
                MoveTowards();
            }

            if (_contactPooler.IsGrounded)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, _isMoving ? AnimState.Run : (_isHighKick ? AnimState.Highkick : AnimState.Idle), true, _animationSpeed);

                Jump();
            }
            else
            {
                Jump();

                if (Mathf.Abs(_view._rigidbody.velocity.y) > _jumpThreshold)
                {
                    _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }
            }
        }
    }
}