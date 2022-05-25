using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TapText : MonoBehaviour
{
	private void OnEnable()
	{
		MoveBegin();
	}


	private void MoveBegin()
	{
		transform.DORotate(new Vector3(0, 0, -30f), 0.3f).OnComplete(() =>
		   {
			   transform.DORotate(new Vector3(0, 0, 30f), 0.5f).OnComplete(() =>
			   {
				   transform.DORotate(Vector3.zero, 0.2f).OnComplete(() =>
					{
						MoveBegin();
					});
			   });
		   });
	}
}
