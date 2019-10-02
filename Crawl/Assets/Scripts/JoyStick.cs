using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Image joystick_Background;
    Image joystick_Image;
    Vector3 inputVector;
    private void Start()
    {
        joystick_Background = GetComponent<Image>();
        joystick_Image = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick_Background.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = pos.x / joystick_Background.rectTransform.sizeDelta.x;
            pos.y = pos.y / joystick_Background.rectTransform.sizeDelta.y;

            inputVector = new Vector3(pos.x * 2, pos.y * 2, 0);
            inputVector = inputVector.magnitude > 1.0f ? inputVector.normalized : inputVector;

            joystick_Image.rectTransform.anchoredPosition = new Vector3(inputVector.x * joystick_Background.rectTransform.sizeDelta.x / 3, inputVector.y * joystick_Background.rectTransform.sizeDelta.y / 3);

        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystick_Image.rectTransform.anchoredPosition = Vector3.zero;

    }

    public float GetHorizontalValue()
    {
        return inputVector.x;
    }
    public float GetVerticalValue()
    {
        return inputVector.y;
    }
}
