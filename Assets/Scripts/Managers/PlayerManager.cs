using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovementController movementController;
    
    private void OnEnable()
    {
        SubscribeEvents();   
    }

    private void SubscribeEvents()
    {
        InputSignals.Instance.onInputTaken += movementController.OnInputTaken;
    }

    private void UnSubscribeEvents()
    {
        InputSignals.Instance.onInputTaken -= movementController.OnInputTaken;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}