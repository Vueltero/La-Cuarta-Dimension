using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI deathsText;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        MainScript.instance.pickUps += coinValue;
        coinsText.text = MainScript.instance.pickUps.ToString();
        MainScript.instance.pickUpsText.text = MainScript.instance.pickUps.ToString();
    }

    public void ChangeDeathsScore()
    {
        MainScript.instance.deaths++;
        deathsText.text = MainScript.instance.deaths.ToString();
        MainScript.instance.deathText.text = MainScript.instance.deaths.ToString();
    }
}
