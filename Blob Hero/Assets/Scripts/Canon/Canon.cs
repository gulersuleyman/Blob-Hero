using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Canon : MonoBehaviour
{
	

	public Transform[] canonPositions;
	public int positionIndex=0;

	
    [SerializeField]Transform playerTransform;




	JoystickRotator _rotator;
	PlayerCollision _playerCollision;
	Bezier _bezier;
	private void Awake()
	{
		_rotator = FindObjectOfType<JoystickRotator>();
		_playerCollision = FindObjectOfType<PlayerCollision>();
		_bezier = FindObjectOfType<Bezier>();
	}
	private void OnEnable()
	{
		positionIndex++;
		if(positionIndex>0)
		{
			transform.position = canonPositions[positionIndex - 1].position;
			transform.LookAt(canonPositions[positionIndex].position);
			transform.eulerAngles = transform.eulerAngles + new Vector3(0, -90, 0);
			
		}
		
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			other.gameObject.transform.eulerAngles = new Vector3(30, 0, 0);
			other.gameObject.transform.position = playerTransform.position;
			other.gameObject.transform.LookAt(canonPositions[positionIndex].position);
			GameManager.Instance.isCanon = true;
			other.gameObject.GetComponent<AnimationController>().WalkAnimation(false);
			other.gameObject.GetComponent<Rigidbody>().isKinematic=true;
			_rotator.Working = false;
			_playerCollision.stopActiver = true;
			_bezier.tapText.gameObject.SetActive(true);
			if (positionIndex > 0)
			{
				_bezier.bezierPointListObjects[0].transform.position = playerTransform.position;
				_bezier.bezierPointListObjects[3].transform.position = canonPositions[positionIndex].position;
				float distance = Vector3.Distance(_bezier.bezierPointListObjects[0].transform.position, _bezier.bezierPointListObjects[3].transform.position);
				if(_bezier.bezierPointListObjects[3].transform.position.x>= _bezier.bezierPointListObjects[0].transform.position.x)
				{
					_bezier.bezierPointListObjects[1].transform.position = new Vector3(_bezier.bezierPointListObjects[0].transform.position.x + distance / 3,
																				   _bezier.bezierPointListObjects[0].transform.position.y,
																				   _bezier.bezierPointListObjects[0].transform.position.z + distance / 3);
					_bezier.bezierPointListObjects[2].transform.position = new Vector3(_bezier.bezierPointListObjects[0].transform.position.x + distance * 2 / 3,
																					   _bezier.bezierPointListObjects[0].transform.position.y,
																					   _bezier.bezierPointListObjects[0].transform.position.z + distance * 2 / 3);
				}
				else
				{
					_bezier.bezierPointListObjects[1].transform.position = new Vector3(_bezier.bezierPointListObjects[0].transform.position.x - distance / 3,
																				   _bezier.bezierPointListObjects[0].transform.position.y,
																				   _bezier.bezierPointListObjects[0].transform.position.z + distance / 3);
					_bezier.bezierPointListObjects[2].transform.position = new Vector3(_bezier.bezierPointListObjects[0].transform.position.x - distance * 2 / 3,
																					   _bezier.bezierPointListObjects[0].transform.position.y,
																					   _bezier.bezierPointListObjects[0].transform.position.z + distance * 2 / 3);
				}
				

			}


		}
	}
}
