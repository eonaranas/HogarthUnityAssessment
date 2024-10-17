using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleEventBus_eon {
    /*
     * This class is the meat of this simple design pattern
     * here is where you going to register(StartListening()) your listener (ObjectListener.cs as an example)
     * and how to trigger such events.
     * 
     * once you call TriggerEvent, every class that register to that event will be notified along with the signature of parameters.
     * it will only notify the same signature of Action that you will pass as an argument to your Trigger
     * 
     * */
    public static class SimpleEventBus {
        static Hashtable eventHash = new Hashtable();

        /*
         * Call this function to start listening on events, make sure you match the signature of the event you want to listen to get 
         * the arguments passed by the calling TriggerEvent
         * */
        public static void StartListening<Y, T>(Y eventName, UnityAction<T> listener) where Y : IComparable, IFormattable, IConvertible {
        
            UnityEvent<T> thisEvent = null;
            string b = GetKey(eventName + typeof(T).ToString());

            if (eventHash.ContainsKey(b)) {
                thisEvent = (UnityEvent<T>)eventHash[b];
                thisEvent.AddListener(listener);
                eventHash[eventName] = thisEvent;
            }
            else {
                thisEvent = new UnityEvent<T>();
                thisEvent.AddListener(listener);
                eventHash.Add(b, thisEvent);
            }
        }

        /*
         * Call this function to start listening on events, make sure you match the signature of the event you want to listen to get 
         * the arguments passed by the calling TriggerEvent (see ObjectListener.cs for example)
         * */
        public static void StartListening<Y>(Y eventName, UnityAction listener) where Y : IComparable, IFormattable, IConvertible {
            UnityEvent thisEvent = null;
            string b = string.Empty;

            if (eventHash.ContainsKey(eventName)) {
                thisEvent = (UnityEvent)eventHash[eventName];
                thisEvent.AddListener(listener);
                eventHash[eventName] = thisEvent;
            }
            else {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                eventHash.Add(eventName, thisEvent);

            }
        }

        /*
         * Make sure to unsubscribe once you decide to stop listening (see ObjectListener.cs for example)
         * */
        public static void StopListening<Y>(Y eventName, UnityAction listener) where Y : IComparable, IFormattable, IConvertible {

            UnityEvent thisEvent = null;

            if (eventHash.ContainsKey(eventName)) {
                thisEvent = (UnityEvent)eventHash[eventName];
                thisEvent.RemoveListener(listener);
                eventHash[eventName] = thisEvent;
            }
        }
        
        /*
         * Make sure to unsubscribe once you decide to stop listening (see ObjectListener.cs for example)
         * */
        public static void StopListening<Y, T>(Y eventName, UnityAction<T> listener) where Y : IComparable, IFormattable, IConvertible {
            UnityEvent<T> thisEvent = null;
            string b = GetKey(eventName + typeof(T).ToString());
            if (eventHash.ContainsKey(b)) {
                thisEvent = (UnityEvent<T>)eventHash[b];
                thisEvent.RemoveListener(listener);
                eventHash[eventName] = thisEvent;
            }
        }

        public static void TriggerEvent<Y, T>(Y eventName, T val) where Y : IComparable, IFormattable, IConvertible {
            UnityEvent<T> thisEvent = null;
            string b = GetKey(eventName + typeof(T).ToString());
            if (eventHash.ContainsKey(b)) {
                thisEvent = (UnityEvent<T>)eventHash[b];
                thisEvent.Invoke(val);
            }
        }

        /*
         * call this function to Trigger an event, every class that listens to the event with same enum type and 
         * same Action with same signature(matching return type and parameters) will be notified and will receive the event
         * along with the arguments passed in calling this event
         * */
        public static void TriggerEvent<Y>(Y eventName) where Y : IComparable, IFormattable, IConvertible {
            UnityEvent thisEvent = null;
            if (eventHash.ContainsKey(eventName)) {
                thisEvent = (UnityEvent)eventHash[eventName];
                thisEvent.Invoke();
            }
        }

        private static string GetKey<T>(T eventName) {
            Type type = typeof(T);
            string key = type.ToString() + eventName.ToString();
            return key;
        }
    }
}