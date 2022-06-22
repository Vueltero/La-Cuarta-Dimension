using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinches : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // reinicia las monedas
            //MainScript.instance.murio = true;

            FindObjectOfType<AudioManager>().Play("death");
            ScoreManager.instance.ChangeScore(MainScript.instance.pickUps * (-1));
            ScoreManager.instance.ChangeDeathsScore();
        }
    }
}
