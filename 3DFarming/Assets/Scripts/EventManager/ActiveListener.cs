using System;
using System.Collections;
using System.Collections.Generic;
using BaseTools;
using UnityEngine;

namespace BaseTools
{
    public class ActiveListener : MonoBehaviour
    {
        private void Awake()
        {
            EventMgr.Register<BoolEventData>(EventID.ACTIVE_OBJ, OnReceiveEvent);
            //EventMgr.Send<BoolEventData>(EventID.ACTIVE_OBJ, new BoolEventData(false));
        }

        private void OnReceiveEvent(BoolEventData a)
        {
            gameObject.SetActive(a.param);
        }

        private void OnDestroy()
        {
            EventMgr.UnRegister<BoolEventData>(EventID.ACTIVE_OBJ, OnReceiveEvent);
        }
    }
}