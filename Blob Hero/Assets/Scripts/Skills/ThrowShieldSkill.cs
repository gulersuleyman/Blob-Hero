using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowShieldSkill : MonoBehaviour
{

	LightningSkill _skill;

	private void Awake()
	{
		_skill = FindObjectOfType<LightningSkill>();
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spear"))
		{
			if (_skill.canMove)
			{
				if (other.gameObject.CompareTag("Enemy"))
				{
					Instantiate(_skill._shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
					Instantiate(_skill._shield.effectPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);

				}
				if (other.gameObject.CompareTag("Spear"))
				{
					Instantiate(_skill._shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
					Instantiate(_skill._shield.effect2Prefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);

				}
				_skill.canMove = false;
				Vector3 targetPos = new Vector3(other.gameObject.transform.position.x, transform.position.y, other.gameObject.transform.position.z);
				_skill.LightningFly(targetPos, other.gameObject);
			}

		}
	}
}
