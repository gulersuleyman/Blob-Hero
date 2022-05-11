using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;



    Rigidbody _rigidbody;
    DynamicJoystick _joystick;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _joystick = FindObjectOfType<DynamicJoystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
        if(direction.x>0.1f || direction.z>0.1f || direction.x < -0.1f || direction.z < -0.1f)
		{
            _rigidbody.AddForce(direction * _moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        
        
    }
}
