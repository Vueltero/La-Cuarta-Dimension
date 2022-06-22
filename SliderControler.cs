using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControler : MonoBehaviour
{
    public Slider slider;
    private float speed = 0.003f;
    public Image fillImage;
    public static SliderControler instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (MainScript.instance.prendioHabilidad == true && MainScript.instance.consumioHabilidad == false)
        {
            slider.value += speed;
            if (slider.value >= 1)
            {
                //consumio toda la energia de su habilidad
                MainScript.instance.consumioHabilidad = true;
                speed = 0.001f;
                fillImage.color = new Color32(255, 120, 120, 255);
            }
        }
        else
        {
            slider.value -= speed;
            if (slider.value <= 0)
            {
                MainScript.instance.consumioHabilidad = false;
                speed = 0.003f;
                fillImage.color = new Color32(255, 255, 255, 255);
            }
        }
    }
}
