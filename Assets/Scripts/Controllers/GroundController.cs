using UnityEngine;

public class GroundController : MonoBehaviour
{
    GroundManager _groundManager;

    private GameObject _obstaclePrefab;

    private void Awake()
    {
        _groundManager = GameObject.FindObjectOfType<GroundManager>();
        _obstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacle");
    }

    private void Start()
    {
        SpawnObstacle();    
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
}