using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenEnemies;

    private BoxShapedRandomSpawner boxShapedRandomSpawner;

    private void Awake()
    {
        boxShapedRandomSpawner = GetComponentInChildren<BoxShapedRandomSpawner>();
    }
    private void Start()
    {       
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            GameObject enemy = boxShapedRandomSpawner.Spawn(enemyPrefab);
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0f);

            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

}
