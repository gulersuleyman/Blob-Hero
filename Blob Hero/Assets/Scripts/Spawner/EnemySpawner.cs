using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int firstJumpBoundary;
    public int secondJumpBoundary;
    public int thirdJumpBoundary;


    public int enemyCount=0;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemy2Prefab;
    [SerializeField] Transform[] points;
    [SerializeField] GameObject parent;


    public bool canSpawn;

    int spawnBoundary;


    float timeBoundary;
    float currentTime;

	private void Start()
	{
        canSpawn = true;
        spawnBoundary = 8;
        timeBoundary = 4;
        currentTime = 0;
	}

	void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>timeBoundary && canSpawn &&!GameManager.Instance.isCanon)
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
                    enemy.transform.parent = parent.transform;
                }
                else
				{
                    GameObject enemy = Instantiate(enemyPrefab, points[i].transform.position, Quaternion.identity);
                    enemy.transform.parent = parent.transform;
                }
                spawnIndex++;
                enemyCount++;
                if(enemyCount==firstJumpBoundary)
				{
                    canSpawn = false;
                    return;

				}
                if (enemyCount == secondJumpBoundary)
                {
                    canSpawn = false;
                    return;

                }
                if (enemyCount == thirdJumpBoundary)
                {
                    canSpawn = false;
                    return;
                }

            }
		}
	}
}
