using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BaseTools
{
    public class EventMgr
    {
        private static EventMgr _instance;

        public static EventMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventMgr();
                }
                return _instance;
            }
        }
        
        //接口。只负责存在在字典中

        //多个注册
        protected class Registerations<T> : IRegisterations
        {
            //委托本身可以一对多注册
            public Action<T> OnReceives = obj => { };
        }
	
        private static Dictionary<int,IRegisterations> eventDic = new Dictionary<int,IRegisterations>();
	
        //注册事件
        public static void Register<T>(int eventId, Action<T> onReceive)
        {
            IRegisterations registerations = null;
            if(eventDic.TryGetValue(eventId,out registerations ))
            {
                Registerations<T> reg = registerations as Registerations<T>;
                reg.OnReceives += onReceive;
            }
            else
            {
                Registerations<T> reg = new Registerations<T>();
                reg.OnReceives += onReceive;
                eventDic.Add(eventId,reg);
            }
        }
	
        //注销事件
        public static void UnRegister<T>(int eventId, Action<T> onReceive)
        {
            IRegisterations registerations = null;
            if(eventDic.TryGetValue(eventId,out registerations ))
            {
                Registerations<T> reg = registerations as Registerations<T>;
                reg.OnReceives -= onReceive;
            }
        }

        public static void Clear(int eventId)
        {
            if (eventDic.ContainsKey(eventId))
            {
                eventDic.Remove(eventId);
            }
        }

        public static void Clear()
        {
            eventDic.Clear();
        }
        
        //发送事件
        public static void Send<T>(int eventId, T t)
        {
            IRegisterations registerations = null;
            if(eventDic.TryGetValue(eventId,out registerations ))
            {
                Registerations<T> reg = registerations as Registerations<T>;
                
                BaseEventData baseData = t as BaseEventData;
                if (baseData != null)
                {
                    baseData.eventID = eventId;
                }
                if (reg != null) reg.OnReceives(t);
            }
        }
    }
    
    public interface IRegisterations
    {
	
    }
}

