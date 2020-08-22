using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : CharacterState
{

    public override void Enter (CharacterController controller)
    {
        controller.playerRigiBody.AddForce (new Vector2 (0, Config.jumpDistance));
    }
    public override void UpdateState (CharacterController controller)
    {
        //Handling any things needed during player being in air
    }
    public override void Exit (CharacterController controller) { }
    public override void InputHandlerDown (CharacterController controller, KeyCode code)
    {
        if (code == KeyCode.UpArrow || code == KeyCode.W)
            controller.UpdateState (this);
    }
    public override void InputHandlerUp (CharacterController controller, KeyCode code) { }
}