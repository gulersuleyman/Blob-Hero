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
}
