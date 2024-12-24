using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChuyenScence3 : MonoBehaviour
{
    [SerializeField] GameObject game;
    [SerializeField] int level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool check = FindObjectOfType<RuongAnim>().ischeckMo();
        if (collision.tag == "Player" && check == true)
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            game.SetActive(true);
        }
    }
}
