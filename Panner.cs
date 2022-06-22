using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panner : MonoBehaviour
{
    public float speed = 1f;
    public GameObject player, panningKillWall;

    //public float playerPositionBorder = 12f;

    void Update()
    {
        Vector2 newPosition = panningKillWall.transform.position;
        newPosition.x += speed * Time.deltaTime;
        //newPosition.y = Mathf.Clamp(player.transform.position.y, 0, 1);
        panningKillWall.transform.position = newPosition;

        /*if (newPosition.x >= player.transform.position.x - 11f)
        {
            MainScript.instance.ReiniciarNivel();
        }*/
    }
}
