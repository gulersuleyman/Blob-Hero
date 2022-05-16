using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
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

		yield return new WaitForSeconds(5f);
		this.gameObject.SetActive(false);
	}
}
