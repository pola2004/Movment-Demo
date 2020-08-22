using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : CharacterState
{
    public override void Enter (CharacterController controller)
    {
        controller.playerRigiBody.AddForce (new Vector2 (0, -(Config.jumpDistance / 0.5f)));
    }
    public override void UpdateState (CharacterController controller)
    {
        //Handling any things needed during player falling to ground
    }
    public override void Exit (CharacterController controller) { }
    public override void InputHandlerDown (CharacterController controller, KeyCode code)
    {
        if (code == KeyCode.DownArrow || code == KeyCode.S)
            if (controller.characterState is Jumping || controller.characterState is Gliding)
                controller.UpdateState (this);
    }
    public override void InputHandlerUp (CharacterController controller, KeyCode code) { }
}