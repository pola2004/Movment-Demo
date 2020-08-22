using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeDash : CharacterStatePower
{
    float nextPossibleDash;

    public override void Enter (CharacterController controller)
    {
        nextPossibleDash = Time.time + Config.chargeTime;
        Debug.Log ("Charing");
    }
    public override void UpdateStatePower (CharacterController controller)
    {
        if (Time.time >= nextPossibleDash)
            controller.UpdateStatePower (controller.characterStatePowerList.Find (x => x.GetType () == Type.GetType ("SuperDash")));
        else
            controller.UpdateStatePower (controller.characterStatePowerList.Find (x => x.GetType () == Type.GetType ("DefaultPower")));
        //Handling any things needed during player super dash to ground
        Debug.Log ("Ready");
    }

    public override void Exit (CharacterController controller)
    {
        Debug.Log ("Charge done");
    }
    public override void InputHandlerDown (CharacterController controller, KeyCode code)
    {
        if (code == KeyCode.V)
            if (controller.characterState is Ducking && controller.characterStatePower is DefaultPower)
                controller.UpdateStatePower (this);
    }
    public override void InputHandlerUp (CharacterController controller, KeyCode code) { }
}