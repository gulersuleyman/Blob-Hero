using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{


    Animator _animator;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void IdleAnimation(bool isIdle)
    {
        if (isIdle == _animator.GetBool("isIdle")) return;

        _animator.SetBool("isIdle", isIdle);
    }
    public void WalkAnimation(bool isWalking)
    {
        if (isWalking == _animator.GetBool("isWalking")) return;

        _animator.SetBool("isWalking", isWalking);
    }
}
