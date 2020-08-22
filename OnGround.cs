using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : CharacterState
{
    public override void Enter (CharacterController controller)
    {
        Debug.Log ("Getting on ground");
    }

    public override void UpdateState (CharacterController controller)
    {
        Debug.Log ("on ground");
    }
    public override void Exit (CharacterController controller)
    {
        Debug.Log ("left ground");
    }
    public override void InputHandlerDown (CharacterController controller, KeyCode code)
    {

    }
    public override void InputHandlerUp (CharacterController controller, KeyCode code) { }
}