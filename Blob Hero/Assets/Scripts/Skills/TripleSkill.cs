using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TripleSkill : MonoBehaviour
{
	[SerializeField] Transform[] points;
    [SerializeField] GameObject rocketPrefab;


	private void OnEnable()
	{
		for (int i = 0; i < 3; i++)
		{
			GameObject rocket = Instantiate(rocketPrefab, transform.position, Quaternion.identity);
			rocket.transform.DOMove(points[i].transform.position, 0.98f).OnComplete(() =>
			 {
				 Destroy(rocket.gameObject);
			 });
		}
		StartCoroutine(ActiveFalse());
	}


	IEnumerator ActiveFalse()
	{

		yield return new WaitForSeconds(1f);
		this.gameObject.SetActive(false);
	}
}
