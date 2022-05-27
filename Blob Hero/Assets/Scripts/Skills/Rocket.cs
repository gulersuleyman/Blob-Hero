using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	ShieldCollision _shield;
	EnemySpawner _spawner;
	private void OnEnable()
	{
		_shield = FindObjectOfType<ShieldCollision>();
		_spawner = FindObjectOfType<EnemySpawner>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") && other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled)
		{
			Instantiate(_shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Instantiate(_shield.effectPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			_shield.canonJumpIndex++;
			Destroy(other.gameObject);
		}
		if(other.gameObject.CompareTag("Spear") && other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled)
		{
			Instantiate(_shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Instantiate(_shield.effect2Prefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			_shield.canonJumpIndex++;
			Destroy(other.gameObject);
		}
		if (_shield.canonJumpIndex == _spawner.canonJumpBoundaries[_spawner.canonJumpIndex])
		{
			_shield.canonTime = true;
		}
	}
}
