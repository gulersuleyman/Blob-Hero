using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSkill : MonoBehaviour
{

	private void OnEnable()
	{
		StartCoroutine(ActiveFalse());
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spear"))
		{
			Destroy(other.gameObject);
		}
	}
	IEnumerator ActiveFalse()
	{
		
		yield return new WaitForSeconds(0.3f);
		this.gameObject.SetActive(false);
	}
}
