using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftArrayLogic : MonoBehaviour
{
    public GameObject ComponentPanel;

    Transform ContentPanel, TextField;

    void Start()
    {
        ContentPanel = transform.Find("Content");
    }

    public bool Add(Item i, int q)
    {
        GameObject cp = Instantiate(ComponentPanel, ContentPanel);
        ComponentPanel cps = cp.GetComponent<ComponentPanel>();
        cps.Start();
        cps.setItem(i);
        cps.setRequiredQuant(q);
        bool can_craft = cps.Refresh();
        return can_craft;
    }

    public void Clear()
    {
        foreach (Transform child in transform.GetChild(0))
        {
            Destroy(child.gameObject);
        }
    }
}
