using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingPanel_logic : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(transform.GetChild(0).GetComponent<slotManagerInv>().contained_Item.name);
    }

    void Start()
    {
        
    }
}
