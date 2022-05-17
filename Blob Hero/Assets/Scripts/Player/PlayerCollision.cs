using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
	[SerializeField] GameObject canvas;
	[SerializeField] Image bar;

	float fillAmount;
	float increaseFillAmount;

	GameCanvasUI _experiences;
	Animator enemyAnim;
	AnimationController _animationController;

	private void Awake()
	{
		_animationController = GetComponent<AnimationController>();
		_experiences = FindObjectOfType<GameCanvasUI>();
	}
	private void Start()
	{
		increaseFillAmount = 0.05f;
		fillAmount = 1;
		
	}

	private void Update()
	{
		canvas.transform.LookAt(Camera.main.transform.position);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
		{
			DecreaseFillAmount();
			Destroy(collision.gameObject, 1f);
		}
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Spear"))
		{
			DecreaseFillAmount();
			enemyAnim= other.gameObject.GetComponentInChildren<Animator>();
			other.gameObject.GetComponent<EnemyController>().follow = false;
			enemyAnim.SetBool("isSpear", true);
			
		}
		if(other.gameObject.CompareTag("Coin"))
		{
			
			_experiences.levelBar.fillAmount += 0.05f;
			if(_experiences.levelBar.fillAmount>0.98f)
			{
				_experiences.levelBar.fillAmount = 0;
			}
			Destroy(other.gameObject);
			Debug.Log("dsd�fs");
		}
	}

	void DecreaseFillAmount()
	{
		fillAmount -= increaseFillAmount;
		bar.fillAmount = fillAmount;
		if (fillAmount < 0.07f)
		{
			fillAmount = 0;
			bar.fillAmount = fillAmount;
			_animationController.DeathAnimation(true);
			canvas.gameObject.SetActive(false);

		}
		
		
	}
}
