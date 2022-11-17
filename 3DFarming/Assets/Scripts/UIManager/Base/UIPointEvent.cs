using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIPointEvent<T> : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityAction<T> onPointerClick;
    public UnityAction<T> onPointEnter;
    public UnityAction<T> onPointerExit;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("============== click");
    }
    
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("============== OnPointerEnter");
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("============== OnPointerExit");
    }
}
