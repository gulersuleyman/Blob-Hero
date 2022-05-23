using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _moveSpeed;

    


    Rigidbody _rigidbody;
    DynamicJoystick _joystick;
    AnimationController _animationcontroller;
    UIManager _uiManager;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _joystick = FindObjectOfType<DynamicJoystick>();
        _animationcontroller = GetComponent<AnimationController>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameManager.Instance.isDead)
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
        
       
       
        
    }
}
