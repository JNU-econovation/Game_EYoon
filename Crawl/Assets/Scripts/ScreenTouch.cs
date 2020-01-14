using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ScreenTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject joystick;
    JoyStick_Main joyStick_Main;

    private void Start()
    {
        joyStick_Main = joystick.GetComponent<JoyStick_Main>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        print("a");
        joystick.transform.position = new Vector3(eventData.position.x, eventData.position.y);
      //  joyStick_Main.OnEnableJoyStick();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("b");
      //  joyStick_Main.DisableJoyStick();
    }
}
