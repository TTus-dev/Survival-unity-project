using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft_inv_interface : In_inv
{
    public int GetCount(Item x)
    {
        int sum = 0;
        foreach (Transform child in hotbar)
        {
            if (child.GetComponent<slotManager>().contained_Item == x)
                sum += child.GetComponent<slotManager>().quant_Item;
        }
        foreach (Transform child in inv)
        {
            if (child.GetComponent<slotManager>().contained_Item == x)
                sum += child.GetComponent<slotManager>().quant_Item;
        }
        return sum;
    }

    public void remove_component(Item x, int no_to_remove)
    {
        slotManager chsm;
        foreach (Transform child in hotbar)
        {
            chsm = child.GetComponent<slotManager>();
            if (chsm.contained_Item == x)
            {
                if (chsm.quant_Item <= no_to_remove)
                {
                    no_to_remove -= chsm.quant_Item;
                    chsm.quant_Item = 0;
                }
                else if (chsm.quant_Item > no_to_remove)
                {
                    chsm.quant_Item -= no_to_remove;
                    no_to_remove = 0;
                }
            }
            if (no_to_remove == 0)
                break;
        }
        if (no_to_remove != 0)
        {
            foreach (Transform child in inv)
            {
                chsm = child.GetComponent<slotManager>();
                if (chsm.contained_Item == x)
                {
                    if (chsm.quant_Item <= no_to_remove)
                    {
                        no_to_remove -= chsm.quant_Item;
                        chsm.quant_Item = 0;
                    }
                    else if (chsm.quant_Item > no_to_remove)
                    {
                        chsm.quant_Item -= no_to_remove;
                        no_to_remove = 0;
                    }
                }
                if (no_to_remove == 0)
                    break;
            }
        }
    }
}
