using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spear"))
		{
			Destroy(other.gameObject);
		}
	}
}
