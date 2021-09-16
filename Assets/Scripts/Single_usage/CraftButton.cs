using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftButton : MonoBehaviour
{
    Picking_up_items Pui;

    Craft_inv_interface Cii;

    slotManager CraftSelection_Slot;

    private void Start()
    {
        Pui = GameObject.Find("Player").GetComponent<Picking_up_items>();
        CraftSelection_Slot = GameObject.Find("Player/Hud/Crafting/CraftingSelected/CraftingSlot").GetComponent<slotManager>();
        Cii = GameObject.Find("Player").GetComponent<Craft_inv_interface>();
    }

    public void Craft()
    {
        Pui.insert_Item(CraftSelection_Slot.contained_Item, CraftSelection_Slot.quant_Item);
        gameObject.GetComponent<Button>().interactable = false;
        gameObject.GetComponent<Button>().interactable = true;
        Craftable CI = CraftSelection_Slot.contained_Item as Craftable;
        for (int i = 0; i < CI.Comps.Length; i++)
        {
            Cii.remove_component(CI.Comps[i], CI.comp_quants[i]);
        }
    }
}
