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
            SpawnTile();
        }    
    }

    public void SpawnTile()
    {
        GameObject temp = Instantiate(_groundTile, _nextSpawnPoint, Quaternion.identity);
        _nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
}