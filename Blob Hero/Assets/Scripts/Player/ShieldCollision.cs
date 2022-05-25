using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
	public GameObject canon1;

	public int canonJumpIndex;


	public GameObject coinPrefab;
	public GameObject effectPrefab;
	public GameObject effect2Prefab;

	UIManager _uiManager;
	EnemySpawner _spawner;

	private void Awake()
	{
		_uiManager = FindObjectOfType<UIManager>();
		_spawner = FindObjectOfType<EnemySpawner>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			canonJumpIndex++;
			
		    GameObject coin=Instantiate(coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			coin.GetComponent<BoxCollider>().size += _uiManager.coinDistance;
			Instantiate(effectPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);

			Destroy(other.gameObject);
		}
		if (other.gameObject.CompareTag("Spear"))
		{
			canonJumpIndex++;
			GameObject coin = Instantiate(coinPrefab, other.gameObject.transform.position+new Vector3(0,3,0), Quaternion.identity);
			coin.GetComponent<BoxCollider>().size += _uiManager.coinDistance;
			Instantiate(effect2Prefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Destroy(other.gameObject);
		}
		if(canonJumpIndex==_spawner.canonJumpBoundaries[_spawner.canonJumpIndex])
		{
			canon1.gameObject.SetActive(true);
		}
	}
}
