using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public GameObject preGame, canvasGame, postGame;
    public static MainScript instance;
    public GameObject whatToSpawnPrefab;
    public bool murio = false, pausarCamara = false;
    private int gamesInScene = 1;
    public bool prendioHabilidad = false;
    public bool consumioHabilidad = false;
    public int deaths = 0, pickUps = 0;
    public TextMeshProUGUI deathText, pickUpsText;
    public TextMeshProUGUI deathsTextOnGame;
    public Slider slider;

    //ya no me dan las neuronas
    public GameObject elCanvasGame, elPostGame;
    public GameObject bgGame, bgPostGame;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        // preguntar nombre

        // animacion historia

        // cargar nivel
        ReiniciarNivel();
    }

    public void ReiniciarNivel()
    {
        gamesInScene = GameObject.FindGameObjectsWithTag("Game").Length;
        if (gamesInScene == 1)
        {
            pausarCamara = true;
            MultipleTargetCamera.instance.targets.Clear();

            Destroy(GameObject.Find("Game"));
            GameObject newGame = Instantiate(whatToSpawnPrefab, whatToSpawnPrefab.transform.position, whatToSpawnPrefab.transform.rotation);
            newGame.name = "Game";

            MultipleTargetCamera.instance.targets.Add(GameObject.Find("Player").transform);
            MultipleTargetCamera.instance.targets.Add(GameObject.Find("Panning Kill Wall").transform);

            pausarCamara = false;

            slider.value = 0f;
        }
        else if (gamesInScene > 1)
        {
            for (int i = 1; i < gamesInScene; i++)
            {
                Destroy(GameObject.Find("Game"));

                //for the bug that generates multiple levels at once
                deaths--;
                deathText.text = deaths.ToString();
                deathsTextOnGame.text = deaths.ToString();
            }
        }
    }

    void Update()
    {
        
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

    public void EnterPortal()
    {
        Destroy(GameObject.Find("Game"));

        GroupChanger(false, elCanvasGame);
        GroupChanger(false, bgGame);
        GroupChanger(true, elPostGame);
        GroupChanger(true, bgPostGame);
    }

    public void SalirClick()
    {
        Application.Quit();
    }

    public void CreditosClick()
    {
        SceneManager.LoadScene(2);
    }
}
