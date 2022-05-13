using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    PlayerController _player;
    NavMeshAgent _agent;

    
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        _agent.destination = _player.transform.position;
    }

}
