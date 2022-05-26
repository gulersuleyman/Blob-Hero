using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LightningSkill : MonoBehaviour
{
	[SerializeField] float skillTime = 2f;
	[SerializeField] GameObject skillTransform;
	[SerializeField] Transform firstPosition;

	public bool canMove;

	public ShieldCollision _shield;

	UIManager _uiManager;
	private void OnEnable()
	{
		_shield = FindObjectOfType<ShieldCollision>();
		canMove = true;
		transform.position = firstPosition.position;
		StartCoroutine(ActiveFalse());
		_shield.gameObject.GetComponent<BoxCollider>().enabled = false;
		_shield.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

		_uiManager = FindObjectOfType<UIManager>();
	}

	
	IEnumerator ActiveFalse()
	{

		yield return new WaitForSeconds(skillTime);
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
			_shield.canonJumpIndex++;
			GameObject coin = Instantiate(_shield.coinPrefab, enemy.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			coin.GetComponent<BoxCollider>().size += _uiManager.coinDistance;
			Instantiate(_shield.effect2Prefab, enemy.gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
			Destroy(enemy);
			canMove = true;
			
		});
	}
}
