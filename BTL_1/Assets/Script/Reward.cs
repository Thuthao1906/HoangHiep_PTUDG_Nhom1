using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Reward : MonoBehaviour
{
    [SerializeField] private GameObject winText; // UI thông báo chiến thắng
    [SerializeField] private float delayBeforeNextScene = 3f; // Thời gian chờ trước khi chuyển màn

    private bool isTriggered = false; // Để tránh kích hoạt nhiều lần

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu người chơi chạm vào phần thưởng
        if (collision.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true; // Đánh dấu đã kích hoạt
            StartCoroutine(WinSequence());
        }
    }

    private IEnumerator WinSequence()
    {
        // Hiển thị thông báo chiến thắng
        if (winText != null)
        {
            winText.SetActive(true);
        }

        // Chờ vài giây
        yield return new WaitForSeconds(delayBeforeNextScene);

        // Chuyển sang màn chơi tiếp theo
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Kiểm tra nếu có màn chơi tiếp theo
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Không còn màn chơi tiếp theo. Kết thúc trò chơi!");
            // Hoặc quay lại màn hình chính:
            // SceneManager.LoadScene("MainMenu");
        }
    }
}
