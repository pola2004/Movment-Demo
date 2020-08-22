using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDash : CharacterStatePower
{
    public override void Enter (CharacterController controller)
    {
        Debug.Log ("Super Charge");
        controller.UpdateStatePower (controller.characterStatePowerList.Find (x => x.GetType () == Type.GetType ("DefaultPower")));
    }

    public override void UpdateStatePower (CharacterController controller)
    {

    }
    public override void Exit (CharacterController controller)
    {

    }
    public override void InputHandlerDown (CharacterController controller, KeyCode code)
    {

    }
    public override void InputHandlerUp (CharacterController controller, KeyCode code) { }
}