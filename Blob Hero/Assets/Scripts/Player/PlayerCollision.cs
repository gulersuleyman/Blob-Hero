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


	AnimationController _animationController;

	private void Awake()
	{
		_animationController = GetComponent<AnimationController>();
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
			fillAmount -= increaseFillAmount;
			bar.fillAmount = fillAmount;
			if(fillAmount<0.07f)
			{
				fillAmount = 0;
				bar.fillAmount = fillAmount;
				_animationController.DeathAnimation(true);
				canvas.gameObject.SetActive(false);

			}
		}
	}
}
