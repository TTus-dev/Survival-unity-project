﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_slot_logic : MonoBehaviour
{
    public slotManagerInv Prev_slot;

    slotManager self_sm;

    private void Start()
    {
        self_sm = transform.GetComponent<slotManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void Reset_Selection()
    {
        if (self_sm.contained_Item != null)
        {
            Prev_slot.contained_Item = self_sm.contained_Item;
            Prev_slot.quant_Item = self_sm.quant_Item;
            self_sm.contained_Item = null;
            self_sm.quant_Item = 0;
            Prev_slot.Display_Update();
            self_sm.Display_Update();
        }
    }
}