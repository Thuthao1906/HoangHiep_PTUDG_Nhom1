using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject health;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(respointHeart());
        }
    }
    IEnumerator respointHeart()
    {
        health.SetActive(false);
        yield return new WaitForSeconds(10);
        health.SetActive(true);
    }
}
