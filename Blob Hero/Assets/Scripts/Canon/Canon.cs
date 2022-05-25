using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Canon : MonoBehaviour
{
    [SerializeField]Transform playerTransform;

	JoystickRotator _rotator;
	PlayerCollision _playerCollision;
	private void Awake()
	{
		_rotator = FindObjectOfType<JoystickRotator>();
		_playerCollision = FindObjectOfType<PlayerCollision>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			other.gameObject.transform.eulerAngles = new Vector3(45, 0, 0);
			other.gameObject.transform.position = playerTransform.position;
			GameManager.Instance.isCanon = true;
			other.gameObject.GetComponent<AnimationController>().WalkAnimation(false);
			other.gameObject.GetComponent<Rigidbody>().isKinematic=true;
			_rotator.Working = false;
			_playerCollision.stopActiver = true;
		    
		}
	}
}
