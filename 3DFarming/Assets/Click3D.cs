using System;
using System.Collections;
using System.Collections.Generic;
using BaseTools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Click3D : MonoBehaviour
{
    private UnityAction<Click3D> action;
    public int eventID = -1;
    public GameObject showObj;
    
    // rotation
    public Transform target;
    public float distance;
    private Quaternion defaultQuaternion;
    private bool talking;
    
    private void Awake()
    {
        defaultQuaternion = transform.rotation;
    }

    public void AddClickEvent(UnityAction<Click3D> action)
    {
        this.action = action;
    }

    private void OnMouseDown()
    {
        // if (EventSystem.current.IsPointerOverGameObject())
        // {
        //     return;
        // }
        // talking = true;
        // if (showObj != null) showObj.SetActive(true);
        // if (action != null) action.Invoke(this);
        // if (eventID != -1)
        // {
        //     EventMgr.Send<BoolEventData>(eventID, new BoolEventData(true));
        // }
    }
    
    private void Update()
    {
        if (talking)
        {
            if (target != null)
            {
                if (Util.GetHorizontalDistance(transform.position, target.position) <= distance)
                {
                    //transform.LookAt(Util.GetLookAtHorizontalPos(transform,target));
                    Util.LookAtHorizontalPos(transform.parent, target);
                }
                else
                {
                    talking = false;
                    transform.parent.rotation = defaultQuaternion;
                    showObj.SetActive(false);
                }
            }
        }
        else
        {
            
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Util.GetHorizontalDistance(transform.position, GameData.Instance.PlayerTsfm.position) <=
                distance)
            {
                talking = true;
                if (showObj != null) showObj.SetActive(true);
                if (action != null) action.Invoke(this);
                if (eventID != -1)
                {
                    EventMgr.Send<BoolEventData>(eventID, new BoolEventData(true));
                }
            }
        }  
    }
}
