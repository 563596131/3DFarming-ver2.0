using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour,IPlayerAnimation
{
    public AnimationClip idleClip;
    public AnimationClip walkClip;
    public AnimationClip jumpClip;
    private Animation ani;    

    private void Awake()
    {
        ani = GetComponent<Animation>();
        ani.AddClip(idleClip, "Idle");
        ani.AddClip(walkClip, "Walk");
        ani.AddClip(jumpClip, "Jump");
    }

    public void PlayJump()
    {
        ani.Play("Jump");
    }

    public void PlayIdle()
    {
        ani.Play("Idle");
    }

    public void PlayWalk()
    {
        ani.Play("Walk");
    }
}
