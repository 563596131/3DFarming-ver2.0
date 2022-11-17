using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour,IPlayerAnimation
{
    public Animator animator;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void PlayJump()
    {
        //animator.Play("Jump");
    }

    public void PlayIdle()
    {
        animator.SetBool("Walk", false);
    }

    public void PlayWalk()
    {
        animator.SetBool("Walk", true);
    }
}
