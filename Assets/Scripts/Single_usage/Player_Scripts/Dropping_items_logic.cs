using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropping_items_logic : MonoBehaviour
{
    public bool outside_inv;

    public Camera player_view;

    slotManager selection_slot;

    private void Start()
    {
        selection_slot = transform.GetChild(7).GetChild(2).GetComponent<slotManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (selection_slot.contained_Item != null && outside_inv)
            {
                Vector3 inst_pos = player_view.transform.position + player_view.transform.forward * 2;
                GameObject dropped = Instantiate(selection_slot.contained_Item.prefab, inst_pos, Quaternion.identity);
                dropped.GetComponent<Item_logic>().contained_items = selection_slot.quant_Item;
                selection_slot.set_quant(0);
            }
        }
    }
}
