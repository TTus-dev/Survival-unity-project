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
                if (selection_slot.contained_Item is Placeable)
                    drop_item(selection_slot.contained_Item.prefab, selection_slot.quant_Item, selection_slot.contained_Item);
                else
                    drop_item(selection_slot.contained_Item.prefab, selection_slot.quant_Item);
                selection_slot.set_quant(0);
            }
        }
    }

    public void drop_item(GameObject item_prefab, int quant, Item Scrptbl = null)
    {
        Vector3 inst_pos = player_view.transform.position + player_view.transform.forward * 2;
        GameObject dropped = Instantiate(item_prefab, inst_pos, Quaternion.identity);
        dropped.GetComponent<Item_logic>().contained_items = quant;
        if (dropped.GetComponent<Item_logic>().scrptbl_obj is Tool)
            dropped.GetComponent<Animator>().enabled = false;
        if (Scrptbl != null)
            dropped.GetComponent<Item_logic>().scrptbl_obj = Scrptbl;
    }
}
