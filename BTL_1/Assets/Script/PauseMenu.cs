using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu; // Đối tượng UI Pause Menu
    private bool isPaused = false; // Trạng thái game có đang bị dừng hay không
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra khi nhấn phím ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Hiển thị Menu Pause
        Time.timeScale = 0f;      // Dừng thời gian trong game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Ẩn Menu Pause
        Time.timeScale = 1f;        // Tiếp tục thời gian
        isPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Đảm bảo thời gian bình thường trước khi thoát
        Debug.Log("Thoát game!");
        Application.Quit(); // Thoát game (chỉ hoạt động khi đã build)
    }
}
