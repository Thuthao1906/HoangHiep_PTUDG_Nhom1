using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        // Thay "GameScene" bằng tên Scene bạn muốn chuyển đến
        SceneManager.LoadScene("Map1");
    }

    // Hàm thoát game
    public void QuitGame()
    {
        // In ra log để kiểm tra trong Editor
        Debug.Log("Thoát game!");
        Application.Quit(); // Chỉ hoạt động khi build game
    }
}
