using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LevelEnemySpawner : MonoBehaviour
{

    /// Internal
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        Bounds boxColliderBounds = boxCollider.bounds;

        /// Find min/max X spawn points based on top collider's box bounds.
        float minSpawnPointX = boxColliderBounds.min.x;
        float maxSpawnPointX = boxColliderBounds.max.x;

        /// Find Y spawn point based on top collider's box center.
        float spawnPointY = boxColliderBounds.center.y;

        float randomSpawnPointX = Random.Range(minSpawnPointX, maxSpawnPointX);

        /// Instantiate enemy!
        Instantiate(enemyPrefab, new Vector3(randomSpawnPointX, spawnPointY, 0f), new Quaternion());
    }

}
