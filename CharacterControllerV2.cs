using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 0.5f;
    public float jumpDistance = 500f;
    public float chargeTime = 5;
    [HideInInspector]
    public float nextPossibleDash;
    Rigidbody2D playerRigiBody;
    #region Private
    private CharacterState characterState;
    private OnGround onGround;
    private Airborne airborne;
    private Gliding gliding;
    private Falling falling;
    private Ducking ducking;
    private CharacterStatePower characterStatePower;
    private DefaultPower defaultPower;
    private ChargeDash chargeDash;
    private SuperDash superDash;

    #endregion
    private void Awake ()
    {
        playerRigiBody = GetComponent<Rigidbody2D> ();
        onGround = new OnGround ();
        airborne = new Airborne ();
        gliding = new Gliding ();
        falling = new Falling ();
        ducking = new Ducking ();
        defaultPower = new DefaultPower ();
        chargeDash = new ChargeDash ();
        superDash = new SuperDash ();
        characterStatePower = defaultPower;
        characterState = onGround;
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
        if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S))
            Ducking ();
        else
            ReleaseDucking ();
        if (Input.GetKey (KeyCode.V))
            ChargingDash ();
    }
    #region  Movements 
    public void MoveCharacter ()
    {
        transform.Translate (Input.GetAxis ("Horizontal") * speed, 0, 0);
    }

    public void Jumping ()
    {
        if (characterState is OnGround)
        {
            UpdateState (airborne);
            playerRigiBody.AddForce (new Vector2 (0, jumpDistance));
        }
        else if (characterState is Airborne)
        {
            UpdateState (gliding);
            playerRigiBody.AddForce (new Vector2 (0, jumpDistance * 0.5f));
        }
    }

    public void Ducking ()
    {
        if (characterState is OnGround)
            UpdateState (ducking);
        else if (characterState is Airborne || characterState is Gliding)
        {
            UpdateState (falling);
            playerRigiBody.AddForce (new Vector2 (0, -(jumpDistance / 0.5f)));
        }
    }
    public void ReleaseDucking ()
    {
        if (characterState is Ducking)
        {
            UpdateState (onGround);
            if (characterStatePower is SuperDash)
                SuperDashPower ();
            else
                UpdateStatePower (defaultPower);
        }
    }
    #endregion

    #region Power Effects 
    public void ChargingDash ()
    {
        if (characterState is Ducking && characterStatePower is DefaultPower)
        {
            nextPossibleDash = Time.time + chargeTime;
            UpdateStatePower (chargeDash);
        }
        characterStatePower.UpdateStatePower (this);

    }
    public void SuperDashPower ()
    {
        Debug.Log ("Super Charge");
        UpdateStatePower (defaultPower);
    }
    #endregion
    public void UpdateState (CharacterState state)
    {
        characterState = state;
    }
    public void UpdateStatePower (CharacterStatePower state)
    {
        characterStatePower = state;
    }
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag ("Ground"))
            UpdateState (onGround);
    }
}