using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftArrayLogic : MonoBehaviour
{
    public GameObject ComponentPanel;

    Transform ContentPanel;

    void Start()
    {
        ContentPanel =  transform.Find("Content");
    }

    public void Add(Item i, int q)
    {
        GameObject cp = Instantiate(ComponentPanel, ContentPanel);
        cp.transform.Find("Text").GetComponent<Text>();
        slotManager cpsm = cp.transform.Find("CraftingSlot").GetComponent<slotManager>();
        cpsm.TurnOffUpdate = true;
        cpsm.change_Item(i);
        cpsm.set_quant(q);
    }

    public void Clear()
    {
        while (ContentPanel.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
