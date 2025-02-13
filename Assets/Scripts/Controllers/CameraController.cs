using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 _offset;
    private Vector3 _targetPos;

    private void Awake()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                return;
            }
        }

        _offset = transform.position - player.position;
    }

    private void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        if (player == null) return;

        _targetPos = player.position + _offset;
        _targetPos.x = 0;
        transform.position = _targetPos;
    }
}