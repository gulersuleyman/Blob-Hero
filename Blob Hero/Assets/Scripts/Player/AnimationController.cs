using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{


    Animator _animator;

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
    public void DeathAnimation(bool isDeath)
    {
        if (isDeath == _animator.GetBool("isDeath")) return;

        _animator.SetBool("isDeath", isDeath);
    }
    public void ThrowAnimation(bool isThrowing)
    {
        if (isThrowing == _animator.GetBool("isThrowing")) return;

        _animator.SetBool("isThrowing", isThrowing);
    }

}
