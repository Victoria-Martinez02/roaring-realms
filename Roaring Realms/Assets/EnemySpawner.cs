using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] short maxSpawn;
    [SerializeField] float minX,maxX,minY,maxY;

    [SerializeField] short curSpawned = 0;
    short options;

    // Update is called once per frame
    void Start()
    {
        options = (short) enemyPrefabs.GetLength(0);
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        StartCoroutine(SpawnEnemyRandomRoutine());
        IEnumerator SpawnEnemyRandomRoutine()
        {
            while(true)
            {
                if(curSpawned < maxSpawn && !Clock.singleton.timePaused)
                    SpawnEnemyRandom();
                yield return new WaitForSeconds(5f);
            }
        }
    }
    
    void SpawnEnemyRandom()
    {
        float randomY = Random.Range(minY,maxY);
        float randomX = Random.Range(minX,maxX);
        int enemy = Random.Range(0,options-1);
        Instantiate(enemyPrefabs[enemy], new Vector3(randomX,randomY,0), Quaternion.identity);
        curSpawned++;
    }

    public void EnemyDefeated()
    {
        curSpawned--;
    }
}

    
