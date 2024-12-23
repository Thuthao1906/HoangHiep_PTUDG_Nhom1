using UnityEngine;

public class RuongAnim : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // Prefab quái vật
    [SerializeField] private int enemyCount = 3;     // Số lượng quái vật cần spawn
    [SerializeField] private Transform[] spawnPoints; // Điểm spawn quái
    [SerializeField] private GameObject reward; // Đối tượng phần thưởng
    [SerializeField] private Transform rewardSpawnPoint; // Vị trí sinh phần thưởng

    private Animator animator;        // Để điều khiển Animator
    private bool isOpened = false; // Trạng thái của rương
    private bool hasSpawnedEnemies = false; // Rương đã sinh quái chưa
    private bool isPlayerNearby = false; // Kiểm tra người chơi có gần rương không
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && !hasSpawnedEnemies && Input.GetKeyDown(KeyCode.E))
        {
            SpawnEnemies();
        }

        if (hasSpawnedEnemies && !isOpened && AreEnemiesDefeated())
        {
            OpenChest();
        }
    }

    private void SpawnEnemies()
    {
        hasSpawnedEnemies = true;


        for (int i = 0; i < enemyCount; i++)
        {
            if (spawnPoints != null && spawnPoints.Length > i)
            {
                Instantiate(enemyPrefab, spawnPoints[i].position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Thiếu điểm spawn cho quái vật.");
            }
        }

        Debug.Log("Đã spawn quái vật! Tiêu diệt tất cả để mở rương.");
    }
    private bool AreEnemiesDefeated()
    {
        // Kiểm tra nếu không còn quái vật trong Scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length == 0;
    }
    private void OpenChest()
    {
        isOpened = true;
        animator.SetTrigger("OpenChest"); // Kích hoạt hoạt ảnh mở rương
        Debug.Log("Rương đã được mở!");
        // Nếu cần, thêm logic spawn phần thưởng ở đây
        if (reward != null && rewardSpawnPoint != null)
        {
            Instantiate(reward, rewardSpawnPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; // Người chơi vào phạm vi tương tác
            Debug.Log("Nhấn phím E để mở rương.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; // Người chơi rời khỏi phạm vi tương tác
        }
    }

    //// [SerializeField] private GameObject enemyPrefab; // Prefab quái vật
    // //[SerializeField] private int enemyCount = 3;     // Số lượng quái vật cần spawn
    // //[SerializeField] private Transform[] spawnPoints; // Điểm spawn quái
    // [SerializeField] private GameObject reward; // Đối tượng phần thưởng
    // [SerializeField] private Transform rewardSpawnPoint; // Vị trí sinh phần thưởng

    // private Animator animator;        // Để điều khiển Animator
    // private bool isOpened = false; // Trạng thái của rương
    // //private bool hasSpawnedEnemies = false; // Rương đã sinh quái chưa
    // private bool isPlayerNearby = false; // Kiểm tra người chơi có gần rương không
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     animator = GetComponent<Animator>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (isPlayerNearby && !isOpened && Input.GetKeyDown(KeyCode.E))
    //     {
    //         OpenChest();
    //     }
    // }



    // private void OpenChest()
    // {
    //     isOpened = true;
    //     animator.SetTrigger("OpenChest"); // Kích hoạt hoạt ảnh mở rương
    //     Debug.Log("Rương đã được mở!");
    //     // Nếu cần, thêm logic spawn phần thưởng ở đây
    //     if (reward != null && rewardSpawnPoint != null)
    //     {
    //         Instantiate(reward, rewardSpawnPoint.position, Quaternion.identity);
    //     }
    // }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         isPlayerNearby = true; // Người chơi vào phạm vi tương tác
    //         Debug.Log("Nhấn phím E để mở rương.");
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         isPlayerNearby = false; // Người chơi rời khỏi phạm vi tương tác
    //     }
    // }
}
