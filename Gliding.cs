using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gliding : CharacterState
{
    public override void Enter (CharacterController controller)
    {
        controller.playerRigiBody.AddForce (new Vector2 (0, Config.jumpDistance * 0.5f));
    }

    public override void UpdateState (CharacterController controller)
    {
        //Handling any things needed during player gliding in air
    }
    public override void Exit (CharacterController controller) { }
    public override void InputHandlerDown (CharacterController controller, KeyCode code)
    {
        if (code == KeyCode.UpArrow || code == KeyCode.W)
            if (controller.characterState is Jumping)
                controller.UpdateState (this);
    }
    public override void InputHandlerUp (CharacterController controller, KeyCode code) { }
}