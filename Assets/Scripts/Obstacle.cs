using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovementController movementController;

    private void Start()
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