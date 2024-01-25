using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Npc_State
{
    public class EventManager : MonoBehaviour
    {
    
        public static EventManager Instance;
        private Dictionary<string, Action<object>> _eventDatabase;

        void Awake()
        {
            Instance = this;
            _eventDatabase = new Dictionary<string, Action<object>>();
        }

        public void SubscribeEvent(string eventName, Action<object> eventAction)
        {
            if(!_eventDatabase.ContainsKey(eventName))
            {
                _eventDatabase.Add(eventName, eventAction);
            }
            else
            {
                _eventDatabase[eventName] += eventAction;
            }
        }
        public void EmitEvent(string eventName, object param)
        {
            _eventDatabase[eventName].Invoke(param);
        }
    }
}

