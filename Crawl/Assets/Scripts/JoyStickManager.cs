using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickManager : MonoBehaviour
{
    public GameObject joyStick;
    JoyStick_Main joystick_Main;
    bool isTouched;
    void Start()
    {
        joystick_Main = joyStick.GetComponent<JoyStick_Main>();
        
    }

    public void DisableJoystick()
    {
        joyStick.SetActive(false);
    }
    public void OnEnableJoystick()
    {
        print(1);
        joyStick.SetActive(true);
    }
    
}
