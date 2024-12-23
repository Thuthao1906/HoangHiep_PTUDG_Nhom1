using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2.0f; // Tốc độ di chuyển lớp
    [SerializeField] private float resetPositionX = -10f; // Vị trí reset
    [SerializeField] private float startPositionX = 10f; // Vị trí bắt đầu


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Reset vị trí nếu cần
        if (transform.position.x <= resetPositionX)
        {
            ResetPosition();
        }
    }
    private void ResetPosition()
    {
        // Đặt nền trở lại vị trí ban đầu
        Vector3 newPosition = transform.position;
        newPosition.x = startPositionX;
        transform.position = newPosition;
    }
}
