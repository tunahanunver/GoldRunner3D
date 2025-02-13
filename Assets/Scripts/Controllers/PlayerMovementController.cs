using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerManager manager;
    [SerializeField] private float speed = 5;
    [SerializeField] private float horizontalMultipler = 2;
    private Rigidbody _rigidbody;
    private float _horizontalInput;

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
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * _horizontalInput * speed * Time.fixedDeltaTime * horizontalMultipler;
        _rigidbody.MovePosition(_rigidbody.position + forwardMove + horizontalMove);
    }
}