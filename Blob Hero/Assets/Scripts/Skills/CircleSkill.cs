using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSkill : MonoBehaviour
{

	ShieldCollision _shield;


	private void OnEnable()
	{
		_shield = FindObjectOfType<ShieldCollision>();
		StartCoroutine(ActiveFalse());
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			Instantiate(_shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Instantiate(_shield.effectPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Destroy(other.gameObject);
		}
		if (other.gameObject.CompareTag("Spear"))
		{
			Instantiate(_shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Instantiate(_shield.effect2Prefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Destroy(other.gameObject);
		}
	}
	IEnumerator ActiveFalse()
	{
		
		yield return new WaitForSeconds(0.3f);
		this.gameObject.SetActive(false);
	}
}
