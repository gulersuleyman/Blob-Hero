using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public bool follow=true;

    PlayerController _player;
    NavMeshAgent _agent;
    SkinnedMeshRenderer _skinnedMesh;
    MeshRenderer _meshRenderer;
    
    void Awake()
    {
        _skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerController>();
        _skinnedMesh.enabled = false;
        if(_meshRenderer !=null)
        _meshRenderer.enabled = false;
    }

    
    void Update()
    {
        if(follow)
		{
            _agent.destination = _player.transform.position;
        }
        
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Island"))
		{
            _skinnedMesh.enabled = true;
            if (_meshRenderer != null)
            _meshRenderer.enabled = true;
        }
	}


}
