using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Heath : MonoBehaviour
{ 
    public GameObject health;
    float amount = 1f;
    Health hoimau;
    private void OnTriggerEnter2D(Collider2D other)
    {
       hoimau = other.GetComponent<Health>();
        
        if (other.tag=="Player")
        {
            hoimau.AddHealth(amount);
        }
    }
   
}
