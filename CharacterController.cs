using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : InputManager
{
    public Rigidbody2D playerRigiBody;
    public List<CharacterState> characterStateList;
    public CharacterState characterState;
    public CharacterStatePower characterStatePower;
    public List<CharacterStatePower> characterStatePowerList;
    private void Awake ()
    {
        KeyHeldEvent += GetPlayerInput;
    }
    void Update ()
    {
        foreach (KeyCode keyCode in Enum.GetValues (typeof (KeyCode)))
        {
            if (Input.GetKeyDown (keyCode))
                KeyPressed (this, keyCode);
            if (Input.GetKeyUp (keyCode))
                KeyReleased (this, keyCode);
            if (Input.GetKey (keyCode))
                KeyHeld (this, keyCode);
        }
    }
    public void GetPlayerInput (CharacterController controller, KeyCode code)
    {
        if (code == KeyCode.LeftArrow || code == KeyCode.A || code == KeyCode.RightArrow || code == KeyCode.D)
            MoveCharacter ();
    }
    #region  Movements 
    public void MoveCharacter ()
    {
        transform.Translate (Input.GetAxis ("Horizontal") * Config.speed, 0, 0);
    }

    #endregion
    public void UpdateState (CharacterState state)
    {
        characterState.Exit (this);
        characterState = state;
        characterState.Enter (this);
    }
    public void UpdateStatePower (CharacterStatePower state)
    {
        characterStatePower.Exit (this);
        characterStatePower = state;
        characterStatePower.Enter (this);
    }
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag ("Ground"))
            UpdateState (characterStateList.Find (x => x.GetType () == Type.GetType ("OnGround")));
    }
}