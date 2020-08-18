using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterState
{
    void UpdateState (CharacterController controller);
}
public class OnGround : CharacterState
{
    public void UpdateState (CharacterController controller)
    {
        //Handling any things needed during player being on ground
    }
}
public class Airborne : CharacterState
{
    public void UpdateState (CharacterController controller)
    {
        //Handling any things needed during player being in air
    }
}
public class Gliding : CharacterState
{
    public void UpdateState (CharacterController controller)
    {
        //Handling any things needed during player gliding in air
    }
}
public class Falling : CharacterState
{
    public void UpdateState (CharacterController controller)
    {
        //Handling any things needed during player falling to ground
        controller.UpdateState (new OnGround ());
    }
}
public class Ducking : CharacterState
{
    public void UpdateState (CharacterController controller)
    {
        //Handling any things needed during player ducking to ground
    }
}