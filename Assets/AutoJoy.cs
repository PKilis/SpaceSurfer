using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoJoy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform joyBG;
    public Joystick joy;

    public void OnPointerDown(PointerEventData ped)
    {
        // Dokunma baþlangýcý
        joyBG.gameObject.SetActive(true);
        Vector2 diff = ped.position - (Vector2)GetComponent<RectTransform>().position;
        Vector2 modifiedDiff = diff * (1f / GetComponentInParent<Canvas>().scaleFactor);
        joyBG.localPosition = modifiedDiff;
    }
    public void OnDrag(PointerEventData ped)
    {
        //Sürükleme
        joy.ChangeJoy(ped.position);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        // Dokunmayý býrakma
        joyBG.gameObject.SetActive(false);
        joy.ResetJoy();
    }

}
