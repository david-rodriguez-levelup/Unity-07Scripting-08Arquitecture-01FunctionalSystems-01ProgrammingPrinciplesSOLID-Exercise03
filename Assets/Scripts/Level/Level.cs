using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{

    /// Inspector
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenEnemies;

    /// Dependencies
    private LevelEnemySpawner levelTopEnemySpawner;

    private void Awake()
    {
        levelTopEnemySpawner = GetComponentInChildren<LevelEnemySpawner>();
    }
    private void Start()
    {       
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            levelTopEnemySpawner.SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

}
