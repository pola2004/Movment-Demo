using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void KeyEvent (KeyCode key);
    public static event System.Action<CharacterController, KeyCode> KeyPressedEvent;
    public static event System.Action<CharacterController, KeyCode> KeyReleasedEvent;
    public static event System.Action<CharacterController, KeyCode> KeyHeldEvent;
    public static void KeyPressed (CharacterController controller, KeyCode code)
    {
        if (KeyPressedEvent != null)
            KeyPressedEvent (controller, code);
    }
    public static void KeyReleased (CharacterController controller, KeyCode code)
    {
        if (KeyReleasedEvent != null)
            KeyReleasedEvent (controller, code);
    }
    public static void KeyHeld (CharacterController controller, KeyCode code)
    {
        if (KeyHeldEvent != null)
            KeyHeldEvent (controller, code);
    }
}