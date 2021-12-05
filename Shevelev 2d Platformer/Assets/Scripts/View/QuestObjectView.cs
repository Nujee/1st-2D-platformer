using UnityEngine;

namespace PlatformerMVC
{
    public class QuestObjectView : LevelObjectView
    {
        [SerializeField] private Color _completedColor;
        private Color _defaultColor;

        [SerializeField] private int _id;

        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        public void ProcessComplete()
        {
            _spriteRenderer.color = _completedColor;
        }

        public void ProcessReset()
        {
            _spriteRenderer.color = _defaultColor;
        }
    }
}