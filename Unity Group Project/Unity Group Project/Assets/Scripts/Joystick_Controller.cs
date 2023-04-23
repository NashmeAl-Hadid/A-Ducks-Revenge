using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick_Controller : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    //Declarations
    private Image baseJoystickImg;
    private Image controlJoystickImg;
    private Vector3 inputVector;

    private void Start()
    {
        baseJoystickImg = GetComponent<Image>();
        controlJoystickImg = transform.GetChild(0).GetComponent<Image>();
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(baseJoystickImg.rectTransform,
            eventData.position, eventData.pressEventCamera, out pos))
        {

            pos.x = (pos.x / baseJoystickImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / baseJoystickImg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(pos.x * 2 - 1, 0, pos.y * 2 - 1);

           //For making joystick more snappy which is more suitable for the movement in the game
            inputVector = (inputVector.magnitude > 0.5f) ? inputVector.normalized : inputVector;

            //Moving Joystick Controller
            controlJoystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (baseJoystickImg.rectTransform.sizeDelta.x / 5),
                inputVector.z * (baseJoystickImg.rectTransform.sizeDelta.y / 5));

        }
    }

    //Return joystick to origin position when not pressing
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        controlJoystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    //Drag joystick on pressing
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    //Movement X
    public float Horizontal()
    {
        if(inputVector.x!=0)
        {
            return inputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    //Movement Y
    public float Vertical()
    {
        if (inputVector.y != 0)
        {
            return inputVector.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }


}
