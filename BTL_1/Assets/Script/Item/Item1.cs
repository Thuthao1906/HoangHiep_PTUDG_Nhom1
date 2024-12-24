using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player")) // Ki?m tra n?u ng??i ch?i thu th?p
        {
            Destroy(gameObject);
        }
    }
}
