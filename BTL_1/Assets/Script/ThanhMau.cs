using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ThanhMau : MonoBehaviour
{
    public Image thanhMau;
    [SerializeField] private Health playerHealth;


    private void Start()
    {
        thanhMau.fillAmount = playerHealth.currentHealth/playerHealth.startingHealth;
    }
    private void Update()
    {
        thanhMau.fillAmount = playerHealth.currentHealth / playerHealth.startingHealth;
    }
}
