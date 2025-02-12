using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;

    private Vector2 startTouchPos;  
    private Vector2 currentTouchPos;
    private float horizontalInput;
    public float horizontalMultipler = 2;
    private bool isDragging = false;  

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultipler;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE  // Bilgisayarda çalıştırıyorsan
            DetectMouseMovement();
        #elif UNITY_ANDROID || UNITY_IOS  // Mobilde çalıştırıyorsan
            DetectSwipe();
        #endif
    }

    // Windows'ta fare sürüklendiğinde hareket etmesi için
    void DetectMouseMovement()
    {
        if (Input.GetMouseButtonDown(0))  // Sol tıklama başladığında
        {
            isDragging = true;
            startTouchPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))  // Sol tıklama bırakıldığında
        {
            isDragging = false;
            horizontalInput = 0;
        }

        if (isDragging)
        {
            currentTouchPos = Input.mousePosition;
            float deltaX = currentTouchPos.x - startTouchPos.x;  // Farenin hareket mesafesi
            horizontalInput = Mathf.Clamp(deltaX / Screen.width * 10, -1, 1);  // Normalleştirme
        }
    }

    // Mobilde dokunmatik kaydırma hareketi için
    void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                currentTouchPos = touch.position;
                float deltaX = currentTouchPos.x - startTouchPos.x;
                horizontalInput = Mathf.Clamp(deltaX / Screen.width * 10, -1, 1);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                horizontalInput = 0;
            }
        }
    }
}