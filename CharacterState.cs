using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState : MonoBehaviour
{
    private void Awake ()
    {
        InputManager.KeyPressedEvent += InputHandlerDown;
        InputManager.KeyReleasedEvent += InputHandlerUp;
    }
    public abstract void Enter (CharacterController controller);
    public abstract void UpdateState (CharacterController controller);
    public abstract void Exit (CharacterController controller);
    public abstract void InputHandlerDown (CharacterController controller, KeyCode code);
    public abstract void InputHandlerUp (CharacterController controller, KeyCode code);
}