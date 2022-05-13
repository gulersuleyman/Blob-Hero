using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemy2Prefab;
    [SerializeField] Transform[] points;
    [SerializeField] Transform parent;

    int spawnBoundary;


    float timeBoundary;
    float currentTime;

	private void Start()
	{
        spawnBoundary = 8;
        timeBoundary = 4;
        currentTime = 0;
	}

	void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>timeBoundary)
		{
            SpawnEnemy();
            currentTime = 0;
		}
    }

    void SpawnEnemy()
	{
        int spawnIndex = 0;

		for (int i = 0; i < points.Length; i++)
		{
            int a= Random.Range(1, 3);
            int b = Random.Range(1, 6);
            if(a==1 && spawnIndex<=spawnBoundary)
			{
                if(b==3)
				{
                    GameObject enemy = Instantiate(enemy2Prefab, points[i].transform.position, Quaternion.identity);
                    enemy.transform.parent = parent;
                }
                else
				{
                    GameObject enemy = Instantiate(enemyPrefab, points[i].transform.position, Quaternion.identity);
                    enemy.transform.parent = parent;
                }
                
                spawnIndex++;
			}
		}
	}
}
