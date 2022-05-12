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
	private void Start()
	{
		increaseFillAmount = 0.25f;
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
		}
	}
}
