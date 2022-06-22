using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHabilidad : MonoBehaviour
{
    public GameObject circuloHabilidadPrendida;
    public GameObject circuloHabilidadApagada;
    public Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //hacer que la habilidad siga el cursor
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        circuloHabilidadPrendida.transform.position = mouseWorldPosition;
        circuloHabilidadApagada.transform.position = mouseWorldPosition;

        //GetMouseButton() Returns true for every frame that the mouse is being pressed.
        if (Input.GetMouseButton(0) && MainScript.instance.prendioHabilidad == false && MainScript.instance.consumioHabilidad == false) // click derecho
        {
            //prender la habilidad
            FindObjectOfType<AudioManager>().Play("powerOn");
            MainScript.instance.prendioHabilidad = true;
            GroupChanger(true, circuloHabilidadPrendida);
            GroupChanger(false, circuloHabilidadApagada);
        }
        else if (!Input.GetMouseButton(0))
        {
            MainScript.instance.prendioHabilidad = false;
            GroupChanger(false, circuloHabilidadPrendida);
            GroupChanger(true, circuloHabilidadApagada);
        }

        //para arreglar un bug que si consumias toda la energia pero seguias manteniendo el click,
        //seguia mostrando la habilidad, lo cual estaba muy roto
        if (MainScript.instance.consumioHabilidad == true)
        {
            MainScript.instance.prendioHabilidad = false;
            GroupChanger(false, circuloHabilidadPrendida);
            GroupChanger(true, circuloHabilidadApagada);
        }
    }

    // para activar o desactivar objetos (para ponerlos visibles o invisibles)
    // es mejor desactivar q poner invisible, es mejor para la performance y desactiva tamb todos los componenstes (y scripts) del objeto
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
