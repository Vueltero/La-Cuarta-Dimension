using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public GameObject canvas;

    private void Start()
    {
        //canvas.transform.position = new Vector3(canvas.transform.position.x, 200.06f, canvas.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (canvas.transform.position.y <= 25f)
        {
            canvas.transform.position = new Vector3(canvas.transform.position.x, 200.06f, canvas.transform.position.z);
        }*/

        if (canvas.transform.position.y >= 1962.66f)
        {
            canvas.GetComponent<CanvasGroup>().alpha -= 0.002f;
            if (canvas.GetComponent<CanvasGroup>().alpha <= 0)
            {
                Debug.Log("EXIT");
                Application.Quit();
            }
        }
    }
}
