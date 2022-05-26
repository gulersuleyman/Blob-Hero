using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
	[SerializeField] float skillTime = 4f;
	ShieldCollision _shield;


	EnemySpawner _spawner;
	

	private void OnEnable()
	{
		_shield = FindObjectOfType<ShieldCollision>();
		_spawner = FindObjectOfType<EnemySpawner>();
		StartCoroutine(ActiveFalse());
		
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
		if (other.gameObject.CompareTag("Spear") && other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled)
		{
			Instantiate(_shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Instantiate(_shield.effect2Prefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			_shield.canonJumpIndex++;
			Destroy(other.gameObject);
		}
		if (_shield.canonJumpIndex == _spawner.canonJumpBoundaries[_spawner.canonJumpIndex])
		{
			_shield.canon1.gameObject.SetActive(true);
		}
	}

	IEnumerator ActiveFalse()
	{

		yield return new WaitForSeconds(skillTime);
		
		this.gameObject.SetActive(false);
	}
}
