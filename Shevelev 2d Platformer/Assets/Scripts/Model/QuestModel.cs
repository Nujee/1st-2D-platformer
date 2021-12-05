﻿using UnityEngine;

namespace PlatformerMVC
{
    public class QuestModel : IQuestModel
    {
        private const string TargetTag = "Player";
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(TargetTag);
        }
    }
}