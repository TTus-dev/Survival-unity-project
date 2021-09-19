using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentPanel : MonoBehaviour
{
    public int requiredQuant;

    slotManager panel_sm;

    Text text;

    Craft_inv_interface icount;

    public void Start()
    {
        panel_sm = transform.GetChild(0).GetComponent<slotManager>();
        text = transform.GetChild(1).GetComponent<Text>();
        icount = GameObject.Find("Player").GetComponent<Craft_inv_interface>();
    }

    public void setItem(Item x)
    {
        panel_sm.change_Item(x, 1);
    }

    public void setRequiredQuant(int a)
    {
        requiredQuant = a;
    }

    public bool Refresh()
    {
        Item i = panel_sm.contained_Item;
        int item_ininv = icount.GetCount(i);
        text.text = $"{i.item_name} {item_ininv} / {requiredQuant}";
        if (item_ininv < requiredQuant)
        {
            text.color = new Color(181, 0, 0, 255);
            return false;
        }
        return true;
    }
}
