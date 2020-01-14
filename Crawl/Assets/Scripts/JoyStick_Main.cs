using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class JoyStick_Main : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 newPos;
    public GameObject background;
    public GameObject handle;
    Image back_Image;
    Image handle_Image;
    public bool canMove;
    private void Start()
    {
        back_Image = background.GetComponent<Image>();
        handle_Image = handle.GetComponent<Image>();
        DisableJoyStick();
    }

    void DisableJoyStick()
    {
        back_Image.color = new Color(back_Image.color.r, back_Image.color.g, back_Image.color.b, 0);
        handle_Image.color = new Color(handle_Image.color.r, handle_Image.color.g, handle_Image.color.b, 0);
        canMove = false;
    }
    void OnEnableJoyStick()
    {
        back_Image.color = new Color(back_Image.color.r, back_Image.color.g, back_Image.color.b, 255);
        handle_Image.color = new Color(handle_Image.color.r, handle_Image.color.g, handle_Image.color.b, 255);
        canMove = true;
    }
  
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnableJoyStick();
        transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DisableJoyStick();
    }
}
