using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LightningSkill : MonoBehaviour
{
	[SerializeField] Transform firstPosition;

	bool canMove;
	private void OnEnable()
	{
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
