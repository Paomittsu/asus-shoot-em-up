using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float  spawnRate = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        yield return wait;
        Instantiate(enemyPrefabs[0], transform.position, Quaternion.identity);
    
        
        
    }
}
