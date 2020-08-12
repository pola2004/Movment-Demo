using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 0.5f;
    public float jumpDistance = 500f;
    Rigidbody2D playerRigiBody;
    private CharacterState characterState;
    private void Awake ()
    {
        playerRigiBody = GetComponent<Rigidbody2D> ();
        characterState = new OnGround ();
    }

    void Update ()
    {
        GetPlayerInput ();
    }

    public void GetPlayerInput ()
    {
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
            MoveCharacter ();
        if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W))
            Jumping ();
        if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S))
            Ducking ();
    }
    #region  Input handling
    public void MoveCharacter ()
    {
        transform.Translate (Input.GetAxis ("Horizontal") * speed, 0, 0);
    }

    public void Jumping ()
    {
        if (characterState is OnGround)
        {
            characterState = new Airborne ();
            playerRigiBody.AddForce (new Vector2 (0, jumpDistance));
        }
        else if (characterState is Airborne)
        {
            characterState = new Gliding ();
            playerRigiBody.AddForce (new Vector2 (0, jumpDistance * 0.5f));
        }
    }

    public void Ducking ()
    {
        if (characterState is OnGround)
            Debug.Log ("Duck");
        else if (characterState is Airborne || characterState is Gliding)
        {
            characterState = new Falling ();
            playerRigiBody.AddForce (new Vector2 (0, -(jumpDistance / 0.5f)));
        }
    }

    #endregion
    public void UpdateState (CharacterState state)
    {
        characterState = state;
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag ("Ground"))
            characterState = new OnGround ();
    }
}