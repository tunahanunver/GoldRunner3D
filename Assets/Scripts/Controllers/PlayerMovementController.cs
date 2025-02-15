using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerManager manager;
    [SerializeField] public float speed = 5;
    [SerializeField] private float horizontalMultipler = 2;
    [SerializeField] public float speedIncreasePerPoint = 0.1f;
    private Rigidbody _rigidbody;
    private float _horizontalInput;

    private bool alive = true;

    private void Awake()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    internal void OnInputTaken(float inputparams)
    {
        _horizontalInput = inputparams;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * _horizontalInput * speed * Time.fixedDeltaTime * horizontalMultipler;
        _rigidbody.MovePosition(_rigidbody.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        Again();
    }

    internal void Die()
    {
        alive = false;
        Invoke("Restart", 2);
    }

    private void Again()
    {
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}