using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSpearEvent : MonoBehaviour
{
	Animator _animator;
    EnemyController _enemyController;
	private void Awake()
	{
		_enemyController = GetComponentInParent<EnemyController>();
		_animator = GetComponent<Animator>();
	}

	public void EndSpear()
	{
		_enemyController.follow = true;
		_animator.SetBool("isSpear", false);
	}
}
