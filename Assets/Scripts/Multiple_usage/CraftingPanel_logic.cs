using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingPanel_logic : MonoBehaviour, IPointerClickHandler
{
    CraftArrayLogic CAL;

    Craftable CraftItem;

    Transform CraftSel;

    void Start()
    {
        transform.GetChild(1).GetComponent<Text>().text = transform.GetChild(0).GetComponent<slotManager>().contained_Item.item_name;
        Transform Craftmenu = transform.parent.parent.parent;
        CAL = Craftmenu.Find("ViewPort2").GetComponent<CraftArrayLogic>();
        CraftItem = transform.Find("CraftingSlot").GetComponent<slotManager>().contained_Item as Craftable;
        CraftSel = Craftmenu.Find("CraftingSelected");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CAL.Clear();
        CraftSel.Find("CraftingSlot").GetComponent<slotManager>().change_Item(CraftItem);
        CraftSel.Find("Text").GetComponent<Text>().text = CraftItem.item_name;
        for (int i = 0; i < CraftItem.Comps.Length; i++)
        {
            CAL.Add(CraftItem.Comps[i], CraftItem.comp_quants[i]);
        }
    }
}
