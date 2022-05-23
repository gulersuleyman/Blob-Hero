using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
	public GameObject coinPrefab;
	public GameObject effectPrefab;
	public GameObject effect2Prefab;

	UIManager _uiManager;


	private void Awake()
	{
		_uiManager = FindObjectOfType<UIManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			
		    GameObject coin=Instantiate(coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			coin.GetComponent<BoxCollider>().size += _uiManager.coinDistance;
			Instantiate(effectPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);

			Destroy(other.gameObject);
		}
		if (other.gameObject.CompareTag("Spear"))
		{
			GameObject coin = Instantiate(coinPrefab, other.gameObject.transform.position+new Vector3(0,3,0), Quaternion.identity);
			coin.GetComponent<BoxCollider>().size += _uiManager.coinDistance;
			Instantiate(effect2Prefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Destroy(other.gameObject);
		}
	}
}
