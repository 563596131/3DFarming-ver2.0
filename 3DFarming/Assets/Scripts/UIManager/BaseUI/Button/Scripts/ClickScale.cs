using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScale : UIButton
{
    public AnimationCurve cure;
    public float from;
    public float to;
    public float animationTime = 1f;
    protected bool doing = false;
    protected float currTime;
    public int times;
    private int currTimes;

    public override void OnClickEvent()
    {
        currTimes = 1;
        doing = true;
        currTime = 0;
        transform.localScale = Vector3.one * from; 
        base.OnClickEvent();
    }

    public void PlayClickAnimation(bool canClick)
    {
        OnClickEvent();
        currTimes = canClick ? 1 : times;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (doing)
        {
            currTime += Time.deltaTime;
            transform.localScale = Vector3.one * Mathf.Lerp(from, to, cure.Evaluate(currTime/animationTime));
            if (currTime >= animationTime)
            {
                currTimes--;
                if (currTimes <= 0)
                {
                    doing = false;
                    transform.localScale = Vector3.one;
                }
                else
                {
                    currTime = 0;
                    transform.localScale = Vector3.one * from;   
                }
            }
        }  
    }
}
