using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Vector2 result;
    public RectTransform joystick;

    public void OnPointerDown(PointerEventData ped)
    {
        // Dokunma baþlangýcý
        ChangeJoy(ped.position);
    }

    public void OnDrag(PointerEventData ped)
    {
        //Sürükleme
        ChangeJoy(ped.position);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        // Dokunmayý býrakma
        ResetJoy();
    }
    
    public void ChangeJoy(Vector2 pedPos)
    {
        Vector2 diff = pedPos - (Vector2)GetComponent<RectTransform>().position;

        Vector2 modifiedDiff = diff * (1f / GetComponentInParent<Canvas>().scaleFactor);

        modifiedDiff /= GetComponent<RectTransform>().sizeDelta * 0.5f;

        result = Vector2.ClampMagnitude(modifiedDiff, 1f);

        modifiedDiff = result * GetComponent<RectTransform>().sizeDelta * 0.5f;

        joystick.localPosition = modifiedDiff;
    }

    public void ResetJoy()
    {
        result = Vector2.zero;

        joystick.localPosition = Vector2.zero;
    }

}
