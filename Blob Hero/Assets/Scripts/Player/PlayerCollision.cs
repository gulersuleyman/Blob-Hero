using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
	[SerializeField] GameObject canvas;
	[SerializeField] Image bar;

	float fillAmount;

	private void Start()
	{
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
			fillAmount -= 0.01f;
			bar.fillAmount = fillAmount;
		}
	}
}
