using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColorText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text theText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = Color.white; //cambia el color del texto al pasar con el mouse por encima
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.black;
    }
}