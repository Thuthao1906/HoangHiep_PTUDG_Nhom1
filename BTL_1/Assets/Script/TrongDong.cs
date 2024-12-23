using UnityEngine;

public class TrongDong : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // Tốc độ xoay (độ mỗi giây)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
