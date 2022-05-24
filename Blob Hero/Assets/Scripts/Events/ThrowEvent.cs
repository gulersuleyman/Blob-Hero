using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEvent : MonoBehaviour
{


    [SerializeField] GameObject shieldThrow;
    AnimationController _animationController;

	private void Awake()
	{
		_animationController = FindObjectOfType<AnimationController>();
	}

	void throwShieldBegin()
	{
        shieldThrow.gameObject.SetActive(true);
		_animationController.ThrowAnimation(false);
	}
        

}
