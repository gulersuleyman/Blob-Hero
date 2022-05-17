using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LightningSkill : MonoBehaviour
{
	[SerializeField] Transform firstPosition;

	bool canMove;

	ShieldCollision _shield;
	private void OnEnable()
	{
		_shield = FindObjectOfType<ShieldCollision>();
		canMove = true;
		transform.position = firstPosition.position;
		StartCoroutine(ActiveFalse());
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spear"))
		{
			if(canMove)
			{
				if (other.gameObject.CompareTag("Enemy"))
				{
					Instantiate(_shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
					Instantiate(_shield.effectPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);

				}
				if (other.gameObject.CompareTag("Spear"))
				{
					Instantiate(_shield.coinPrefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
					Instantiate(_shield.effect2Prefab, other.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);

				}
				canMove = false;
				Vector3 targetPos = new Vector3(other.gameObject.transform.position.x, transform.position.y, other.gameObject.transform.position.z);
				LightningFly(targetPos, other.gameObject);
			}
			
		}
	}
	IEnumerator ActiveFalse()
	{

		yield return new WaitForSeconds(2f);
		this.gameObject.SetActive(false);
	}

	void LightningFly(Vector3 pos,GameObject enemy)
	{
		transform.DOMove(pos, 0.25f).SetEase(Ease.Linear).OnComplete(() =>
		{
			Destroy(enemy);
			canMove = true;
		});
	}
}
