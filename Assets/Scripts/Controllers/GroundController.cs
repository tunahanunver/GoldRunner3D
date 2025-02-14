using UnityEngine;

public class GroundController : MonoBehaviour
{
    GroundManager _groundManager;

    private GameObject _obstaclePrefab;
    private GameObject _coinPrefab;

    private void Awake()
    {
        _groundManager = GameObject.FindObjectOfType<GroundManager>();
        _obstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacle");
        _coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");
    }

    private void Start()
    {
        SpawnObstacle();
        SpawnCoins();    
    }

    private void OnTriggerExit(Collider other)
    {
        _groundManager.SpawnTile();
        Destroy(gameObject, 1);
    }

    private void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(_obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    private void SpawnCoins()
    {
        int CoinsToSpawn = 10;

        for (int i = 0; i < CoinsToSpawn; i++)
        {
            GameObject temp = Instantiate(_coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}