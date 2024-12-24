using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtOK : MonoBehaviour
{
    [SerializeField] private GameObject game;

   public void Ok()
    {
        game.SetActive(false);
    }
}
