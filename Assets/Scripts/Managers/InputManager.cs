using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 _startMousePos;
    private Vector2 _currentMousePos;
    private float _horizontalInput;
    private bool _isDragging = false;

    void Update()
    {
        GetInputValues();
        if (!Input.anyKey) return;
        SendInput();
    }

    private void SendInput()
    {
        InputSignals.Instance.onInputTaken?.Invoke(_horizontalInput);
    }

    private void GetInputValues()
    {
        if (Input.GetMouseButtonDown(0))  // Mouse sol tık başladığında
        {
            _isDragging = true;
            _startMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))  // Mouse bırakıldığında
        {
            _isDragging = false;
            _horizontalInput = 0;
        }

        if (_isDragging)
        {
            _currentMousePos = Input.mousePosition;
            float deltaX = _currentMousePos.x - _startMousePos.x; // Mouse'un x ekseninde ne kadar hareket ettiğini hesapla
            _horizontalInput = Mathf.Clamp(deltaX / Screen.width * 10, -1, 1);  // Hareketi normalize et
        }
    }
}