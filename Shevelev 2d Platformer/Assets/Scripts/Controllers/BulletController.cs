using UnityEngine;
namespace PlatformerMVC
{
    public class BulletController
    {
        private Vector3 _velocity;
        private LevelObjectView _view;

        public BulletController(LevelObjectView view)
        {
            _view = view;
            Active(false);
        }

        public void Active(bool val)
        {
            _view.gameObject.SetActive(val);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            float _angle = Vector3.Angle(Vector3.down, _velocity);
            Vector3 _axis = Vector3.Cross(Vector3.down, _velocity);
            _view._transform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            Active(true);
            SetVelocity(velocity);

            _view._transform.position = position;
            _view._rigidbody.velocity = Vector2.zero;
            _view._rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}