using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

	public Tilemap tilemap;
	public Grid grid;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
	}

	public void OnLanding()
    {
		animator.SetBool("IsJumping", false);
    }

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Coin"))
		{
			Destroy(other.gameObject);
		}
		if (other.gameObject.CompareTag("Pinche"))
		{
			// animacion de muerte

			// reiniciar el nivel
			MainScript.instance.ReiniciarNivel();
		}
		if (other.gameObject.CompareTag("Portal"))
		{
			FindObjectOfType<AudioManager>().Play("enterPortal");
			MainScript.instance.EnterPortal();
		}
	}
}
