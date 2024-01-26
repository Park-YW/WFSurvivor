using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class EventManager : MonoBehaviour
    {
    
        private static EventManager _instance;
        public static EventManager Instance{
            get{

                if(_instance == null) _instance = FindFirstObjectByType<EventManager>();
                if(_instance == null) {
                    var go = new GameObject(nameof(EventManager));
                    _instance = go.AddComponent<EventManager>();
                }

                return _instance;
            }
        }
        private Dictionary<string, Action<object>> _eventDatabase;

        void Awake()
        {
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


