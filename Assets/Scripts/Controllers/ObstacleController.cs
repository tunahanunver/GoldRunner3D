using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    PlayerMovementController movementController;

    private void Awake()
    {
        movementController = GameObject.FindObjectOfType<PlayerMovementController>();    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            movementController.Die();
        }
    }
}