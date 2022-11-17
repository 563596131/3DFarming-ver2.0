using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Util
{
    public static float GetHorizontalDistance(Vector3 from, Vector3 to)
    {
        from.y = 0;
        to.y = 0;
        float dis = Vector3.Distance(from, to);
        return dis;
    }

    public static Vector3 GetLookAtHorizontalPos(Transform my, Transform target)
    {
        Vector3 pos = target.position;
        pos.y = my.position.y;
        return pos;
    }
    
    public static void LookAtHorizontalPos(Transform from, Transform to)
    {
        Vector3 pos = to.position;
        pos.y = from.position.y;
        from.LookAt(pos);
    }

    #region delay action
    public static void DelayAction(MonoBehaviour mono, float delayTime, UnityAction action)
    {
        mono.StartCoroutine(DelayAction(delayTime, action));
    }
    
    public static IEnumerator DelayAction(float delayTime, UnityAction action)
    {
        yield return new WaitForSeconds(delayTime);
        if (action != null)
        {
            action.Invoke();
        }
    }
    #endregion

}
