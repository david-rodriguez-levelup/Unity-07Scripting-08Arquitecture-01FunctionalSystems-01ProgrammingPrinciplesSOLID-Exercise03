using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenEnemies;

    private SpawnFromBoxCollider spawner;

    private void Awake()
    {
        spawner = GetComponentInChildren<SpawnFromBoxCollider>();
    }
    private void Start()
    {       
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            GameObject enemy = spawner.Spawn(enemyPrefab);
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0f);

            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

}
