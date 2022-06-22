using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("pickUp");
            ScoreManager.instance.ChangeScore(coinValue);
            SliderControler.instance.slider.value -= 0.2f;
        }
    }
}
