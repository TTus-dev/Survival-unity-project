using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Dropping_items_logic dil;

    // Start is called before the first frame update
    void Start()
    {
        dil = GameObject.Find("Player/Hud").GetComponent<Dropping_items_logic>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        dil.outside_inv = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dil.outside_inv = true;
    }
}
