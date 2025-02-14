using UnityEngine;

public class CoinController : MonoBehaviour
{
    private float _turnSpeed = 90f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObstacleController>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

        ScoreManager.inst.IncrementScore();

        Destroy(gameObject);
    }

    private void Update()
    {
        Rotate();    
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, _turnSpeed * Time.deltaTime);
    }
}