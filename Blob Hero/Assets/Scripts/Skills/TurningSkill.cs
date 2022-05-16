using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningSkill : MonoBehaviour
{
    public float turnSpeed;
    [SerializeField] Transform playerTransform;
    void Update()
    {
        transform.position = playerTransform.position;
        transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * turnSpeed);
    }
}
