using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour
{

    public GameObject UI;
    
    private void OnMouseUp()
    {
        UI.SetActive(!UI.activeSelf);
    }
}