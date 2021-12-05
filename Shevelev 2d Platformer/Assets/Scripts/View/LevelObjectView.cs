using System;
using UnityEngine;

namespace PlatformerMVC
{

    public class LevelObjectView : MonoBehaviour
    {

        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Collider2D _collider;
        public Rigidbody2D _rigidbody;

        public Action<LevelObjectView> OnLevelObjectContact { get; set; }
        
        void Start()
        {
            _transform = GetComponent<Transform>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            LevelObjectView temp = collision.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(temp); // = if(OnLevelObjectContact != null) {  }
        }
    }
}