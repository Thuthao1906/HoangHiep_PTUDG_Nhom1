using UnityEngine;
using UnityEngine.SceneManagement;
public class ChuyenManMap1 : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) // Ki?m tra n?u ng??i ch?i thu th?p
        {
            SceneManager.LoadScene("Map2");
        }
    }
}
