using UnityEngine;

public class GroundManager : MonoBehaviour
{
    private GameObject _groundTile;
    private Vector3 _nextSpawnPoint;

    private void Awake()
    {
        _groundTile = Resources.Load<GameObject>("Prefabs/GroundTile");
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 1)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }    
    }

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(_groundTile, _nextSpawnPoint, Quaternion.identity);
        _nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<GroundController>().SpawnObstacle();
            temp.GetComponent<GroundController>().SpawnCoins();
        }
    }
}