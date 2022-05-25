using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float _moveSpeed;


    bool bezierMove;

    JoystickRotator _rotator;
    Rigidbody _rigidbody;
    DynamicJoystick _joystick;
    AnimationController _animationcontroller;
    UIManager _uiManager;
    Bezier _bezier;
    PlayerCollision _playercollision;
    EnemySpawner _spawner;
    // Start is called before the first frame update
    void Awake()
    {
        _rotator = GetComponent<JoystickRotator>();
        _rigidbody = GetComponent<Rigidbody>();
        _joystick = FindObjectOfType<DynamicJoystick>();
        _animationcontroller = GetComponent<AnimationController>();
        _uiManager = FindObjectOfType<UIManager>();
        _bezier = FindObjectOfType<Bezier>();
        _playercollision = GetComponent<PlayerCollision>();
        _spawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameManager.Instance.isDead && !GameManager.Instance.isCanon)
		{
            Vector3 direction = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
            if (direction.x > 0.1f || direction.z > 0.1f || direction.x < -0.1f || direction.z < -0.1f)
            {
                _rigidbody.isKinematic = false;
                // _rigidbody.AddForce(direction * _moveSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
                _rigidbody.velocity = direction * (_moveSpeed+_uiManager.moveSpeedIncreaser) * Time.fixedDeltaTime;
                _animationcontroller.WalkAnimation(true);
            }

            if (direction == Vector3.zero)
            {
                _animationcontroller.WalkAnimation(false);
                _rigidbody.isKinematic = true;
            }
        }
        if(GameManager.Instance.isCanon && Input.GetMouseButtonDown(0) && !bezierMove)
		{
            StartCoroutine(BezierMove());
		}
        
    }
    IEnumerator BezierMove()
	{
        bezierMove = true;
		for (int i = 0; i < 100; i++)
		{
            transform.position = _bezier.lineRenderer.GetPosition(i);
            yield return new WaitForSeconds(0.01f);
            
                
			
		}
        transform.position = new Vector3(transform.position.x, -1.7f, transform.position.z);
        GameManager.Instance.isCanon = false;
        _rotator.Working = true;
        transform.eulerAngles = Vector3.zero;
        _playercollision.stopActiver = false;
        bezierMove = false;
        _spawner.canSpawn = true;
        
        yield return null;
	}
}
