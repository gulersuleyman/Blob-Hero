using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public bool follow = false;

    PlayerController _player;
    NavMeshAgent _agent;
    ShieldCollision _shield;

    void Awake()
    {
        
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerController>();
        _shield = FindObjectOfType<ShieldCollision>();
        
    }
    void Update()
    {
        if (follow && !GameManager.Instance.isCanon)
        {
            _agent.destination = _player.transform.position;
        }

    }
	private void OnTriggerEnter(Collider other)
	{
        if(!other.gameObject.CompareTag("Island") && other.gameObject.CompareTag("BossActiver") && !other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Spear"))
		{
            follow = true;
            transform.localScale = transform.localScale - new Vector3(0.5f, 0.5f, 0.5f);

            if (transform.localScale.x <= 1.7f)
			{
                Destroy(this.gameObject);
                GameObject effecct= Instantiate(_shield.effectPrefab, other.gameObject.transform.position + new Vector3(0, 4, 0), Quaternion.identity);
                effecct.transform.localScale = effecct.transform.localScale * 3;
            }
                
        }
        
	}
	private void OnTriggerStay(Collider other)
	{
        
        if (!other.gameObject.CompareTag("Island") && !other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Spear") && !other.gameObject.CompareTag("BossActiver"))
        {
            follow = true;
            transform.localScale = transform.localScale - new Vector3(0.04f, 0.04f, 0.04f);

            if (transform.localScale.x <= 1.7f)
            {
                Destroy(this.gameObject);
                GameObject effecct = Instantiate(_shield.effectPrefab, other.gameObject.transform.position + new Vector3(0, 4, 0), Quaternion.identity);
                effecct.transform.localScale = effecct.transform.localScale * 3;
            }

        }

    }
}
