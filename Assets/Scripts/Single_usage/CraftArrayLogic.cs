using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftArrayLogic : MonoBehaviour
{
    public GameObject ComponentPanel;

    Transform ContentPanel, TextField;

    Craft_inv_interface icount;

    void Start()
    {
        ContentPanel = transform.Find("Content");
        icount = transform.parent.parent.parent.GetComponent<Craft_inv_interface>();
    }

    public bool Add(Item i, int q)
    {
        GameObject cp = Instantiate(ComponentPanel, ContentPanel);
        int item_ininv = icount.GetCount(i);
        cp.transform.Find("Text").GetComponent<Text>().text = $"{i.item_name} {item_ininv} / {q}";
        slotManager cpsm = cp.transform.Find("CraftingSlot").GetComponent<slotManager>();
        cpsm.TurnOffUpdate = true;
        cpsm.change_Item(i, 1);
        if (item_ininv < q)
        {
            cp.transform.Find("Text").GetComponent<Text>().color = new Color(181, 0, 0, 255);
            return false;
        }
        return true;
    }

    public void Clear()
    {
        foreach (Transform child in transform.GetChild(0))
        {
            Destroy(child.gameObject);
        }
    }
}
