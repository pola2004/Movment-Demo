using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPower : CharacterStatePower
{
    public override void Enter (CharacterController controller) { }

    public override void Exit (CharacterController controller) { }

    public override void UpdateStatePower (CharacterController controller)
    {
        //Handling any things needed during player default power
    }
    public override void InputHandlerDown (CharacterController controller, KeyCode code) { }
    public override void InputHandlerUp (CharacterController controller, KeyCode code) { }
}