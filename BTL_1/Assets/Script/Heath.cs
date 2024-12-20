using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Heath : MonoBehaviour
{ 
    public GameObject health;
    float amount = 1f;
    Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
       player = other.GetComponent<Player>();
        
        if (other.tag=="Player")
        {
            player.Heal(amount);
        }
    }
   
}
