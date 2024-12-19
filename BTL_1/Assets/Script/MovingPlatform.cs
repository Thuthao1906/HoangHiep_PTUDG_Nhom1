using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f; // Tốc độ di chuyển
    public float moveRange = 5f; // Phạm vi di chuyển lên xuống
    private Vector3 startPosition; // Vị trí bắt đầu

    private bool movingUp = true; // Trạng thái di chuyển
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }
    void MovePlatform()
    {
        // Kiểm tra trạng thái di chuyển
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + moveRange)
                movingUp = false; // Đảo chiều xuống
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y <= startPosition.y - moveRange)
                movingUp = true; // Đảo chiều lên
        }
    }
}
