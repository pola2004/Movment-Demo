using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterStatePower
{
    void UpdateStatePower (CharacterController controller);
}
public class DefaultPower : CharacterStatePower
{
    public void UpdateStatePower (CharacterController controller)
    {
        //Handling any things needed during player default power
    }
}
public class ChargeDash : CharacterStatePower
{
    public void UpdateStatePower (CharacterController controller)
    {
        if (Time.time >= controller.nextPossibleDash)
            controller.UpdateStatePower (new SuperDash ());
        //Handling any things needed during player super dash to ground
    }
}
public class SuperDash : CharacterStatePower
{
    public void UpdateStatePower (CharacterController controller)
    {
        //Handling any things needed during player super dash to ground
    }
}