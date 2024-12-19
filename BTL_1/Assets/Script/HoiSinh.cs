using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class HoiSinh : MonoBehaviour
{
   public void LoadScence()
    {
        int numberScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(numberScene);
    }
}
