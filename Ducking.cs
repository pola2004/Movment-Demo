using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducking : CharacterState
{
    public override void Enter (CharacterController controller)
    {
        Debug.Log ("Ducking");
    }

    public override void UpdateState (CharacterController controller)
    {
        //Handling any things needed during player ducking to ground
    }
    public override void Exit (CharacterController controller) { }
    public override void InputHandlerDown (CharacterController controller, KeyCode code)
    {
        if (code == KeyCode.DownArrow || code == KeyCode.S)
            if (controller.characterState is OnGround)
                controller.UpdateState (this);
    }
    public override void InputHandlerUp (CharacterController controller, KeyCode code)
    {
        if (code == KeyCode.DownArrow || code == KeyCode.S)
            if (controller.characterState is Ducking)
            {
                controller.UpdateState (controller.characterStateList.Find (x => x.GetType () == Type.GetType ("OnGround")));
                if (controller.characterStatePower is ChargeDash)
                    controller.characterStatePower.UpdateStatePower (controller);
                else
                    controller.UpdateStatePower (controller.characterStatePowerList.Find (x => x.GetType () == Type.GetType ("DefaultPower")));
            }
    }
}