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

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spear"))
		{
			if(canMove)
			{
				canMove = false;
				Vector3 targetPos = new Vector3(other.gameObject.transform.position.x, transform.position.y, other.gameObject.transform.position.z);
				transform.DOMove(targetPos, 0.5f).OnComplete(() =>
				{
					Destroy(other.gameObject);
					canMove = true;
				});
			}
			
		}
	}
	IEnumerator ActiveFalse()
	{

		yield return new WaitForSeconds(3f);
		this.gameObject.SetActive(false);
	}
}
