using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LightningSkill : MonoBehaviour
{

	private void OnEnable()
	{
		StartCoroutine(ActiveFalse());
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spear"))
		{
			Vector3 targetPos = new Vector3(other.gameObject.transform.position.x, transform.position.y, other.gameObject.transform.position.z);
			transform.DOMove(targetPos, 0.5f).OnComplete(() =>
			{
				Destroy(other.gameObject);
			});
		}
	}
	IEnumerator ActiveFalse()
	{

		yield return new WaitForSeconds(3f);
		this.gameObject.SetActive(false);
	}
}
