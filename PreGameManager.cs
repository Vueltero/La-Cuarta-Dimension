using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PreGameManager : MonoBehaviour
{
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.transform.position.y >= 1962.66f)
        {
            canvas.GetComponent<CanvasGroup>().alpha -= 0.002f;
            if (canvas.GetComponent<CanvasGroup>().alpha <= 0)
            {
                //switch scenes 
                SceneManager.LoadScene(1);
            }
        }
    }

    private void GroupChanger(bool x, GameObject y)
    {
        if (x)
        {
            y.gameObject.SetActive(true);
            return;
        }
        y.SetActive(false);
    }
}


//canvas termina en pos.y = 2742