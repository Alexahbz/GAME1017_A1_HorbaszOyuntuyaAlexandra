using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval;
    [SerializeField] List<GameObject> activeEnemies;

    void Start()
    {
        activeEnemies = new List<GameObject>();
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnEnemy();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < activeEnemies.Count; i++)
            {
                Destroy(activeEnemies[i]);
            }
            activeEnemies.Clear();
        }
    }

    void SpawnEnemy()
    {     
        GameObject enemyInst = Instantiate(enemyPrefab, new Vector3(7.16f, Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
        activeEnemies.Add(enemyInst);

    }
}
