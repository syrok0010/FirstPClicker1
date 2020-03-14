using System;
using UnityEngine;

namespace Clicker
{
    public class EventsAggregator : MonoBehaviour
    {
        private static event Action OnBonusChange;

        public static void Subscribe(Action toAdd, string whereToAdd)
        {
            OnBonusChange += toAdd;
            Debug.Log("Subscribed");
        }
    
        public static void Publish()
        {
            OnBonusChange?.Invoke();
        }
    }
}