using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject effect;
    public bool follow=true;

    PlayerController _player;
    NavMeshAgent _agent;

    
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        if(follow)
		{
            _agent.destination = _player.transform.position;
        }
        
    }

	private void OnDestroy()
	{
       Instantiate(coinPrefab, transform.position, Quaternion.identity); 

       GameObject e= Instantiate(effect.gameObject,transform.position, Quaternion.identity);
       Destroy(e.gameObject, 1f);
	}

}
