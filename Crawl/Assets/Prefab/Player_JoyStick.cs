using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Player_JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Image bg;
    Image joyStickImg;
    Vector3 inputVector;
    private void Start()
    {
        bg = GetComponent<Image>();
        joyStickImg = transform.GetChild(0).GetComponent<Image>();

    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = pos.x / bg.rectTransform.sizeDelta.x;
            pos.y = pos.y / bg.rectTransform.sizeDelta.y;

            inputVector = new Vector3(pos.x * 2, pos.y * 2, 0);
            inputVector = inputVector.magnitude > 1.0f ? inputVector.normalized : inputVector;

            joyStickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * bg.rectTransform.sizeDelta.x / 3, inputVector.y * bg.rectTransform.sizeDelta.y / 3);

        }
    }

    public virtual void OnPointerDown(PointerEventData ped) 
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joyStickImg.rectTransform.anchoredPosition = Vector3.zero;

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
