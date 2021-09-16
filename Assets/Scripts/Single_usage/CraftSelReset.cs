using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSelReset : MonoBehaviour
{
    public void Reset()
    {
        Transform Cslot = transform.Find("CraftingSlot");
        Cslot.GetComponent<slotManager>().change_Item(null);
        Cslot.GetComponent<slotManager>().set_quant(0);
        Cslot.Find("Item_image").gameObject.SetActive(false);
    }
}
