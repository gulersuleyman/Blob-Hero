using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowShieldSkill : MonoBehaviour
{
	LightningSkill _skill;
	ShieldCollision _shield;
	EnemySpawner _spawner;
	private void Awake()
	{
		_shield = FindObjectOfType<ShieldCollision>();
		_skill = FindObjectOfType<LightningSkill>();
		_spawner = FindObjectOfType<EnemySpawner>();
	}
	
	

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spear"))
		{
			if (_skill.canMove)
			{
				_skill.canMove = false;
				Vector3 targetPos = new Vector3(other.gameObject.transform.position.x, transform.position.y, other.gameObject.transform.position.z);
				if(other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled && other.gameObject!=null)
				{
					_skill.LightningFly(targetPos, other.gameObject);
					return;
				}
				
			}

		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			Instantiate(_shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Instantiate(_shield.effectPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			_shield.canonJumpIndex++;
			Destroy(other.gameObject);
		}
		if (other.gameObject.CompareTag("Spear"))
		{
			Instantiate(_shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Instantiate(_shield.effect2Prefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			_shield.canonJumpIndex++;
			Destroy(other.gameObject);
		}
		if (_shield.canonJumpIndex == _spawner.firstJumpBoundary)
		{
			_shield.canon1.gameObject.SetActive(true);
		}
	}
}
