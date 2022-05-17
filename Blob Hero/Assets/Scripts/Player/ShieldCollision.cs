using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
	public GameObject coinPrefab;
	public GameObject effectPrefab;
	public GameObject effect2Prefab;
	

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			Instantiate(coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Instantiate(effectPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);

			Destroy(other.gameObject);
		}
		if (other.gameObject.CompareTag("Spear"))
		{
			Instantiate(coinPrefab, other.gameObject.transform.position+new Vector3(0,3,0), Quaternion.identity);
			Instantiate(effect2Prefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Destroy(other.gameObject);
		}
	}
}
