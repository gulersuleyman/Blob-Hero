using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LightningSkill : MonoBehaviour
{
	[SerializeField] GameObject skillTransform;
	[SerializeField] Transform firstPosition;

	public bool canMove;

	public ShieldCollision _shield;
	private void OnEnable()
	{
		_shield = FindObjectOfType<ShieldCollision>();
		canMove = true;
		transform.position = firstPosition.position;
		StartCoroutine(ActiveFalse());
		_shield.gameObject.GetComponent<BoxCollider>().enabled = false;
		_shield.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
		
		
	}

	
	IEnumerator ActiveFalse()
	{

		yield return new WaitForSeconds(2f);
		transform.DOMove(_shield.gameObject.transform.position, 0.1f).OnComplete(() =>
		{
			skillTransform.gameObject.SetActive(false);
			_shield.gameObject.GetComponent<BoxCollider>().enabled = true;
			_shield.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
			this.gameObject.SetActive(false);
			
		});
		
	}

	public void LightningFly(Vector3 pos,GameObject enemy)
	{
		transform.DOMove(pos, 0.25f).SetEase(Ease.Linear).OnComplete(() =>
		{
			Destroy(enemy);
			canMove = true;
			
		});
	}
}
