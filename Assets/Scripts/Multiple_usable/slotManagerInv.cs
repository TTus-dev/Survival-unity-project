using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slotManagerInv : slotManager, IPointerClickHandler
{
    slotManager Selection_slotsm;
    Selection_slot_logic Selection_slotl;
    Picking_up_items pui_script;

    private new void Start()
    {
        base.Start();
        Selection_slotsm = GameObject.Find("Player/Hud/Inventory/Selection").GetComponent<slotManager>();
        Selection_slotl = GameObject.Find("Player/Hud/Inventory/Selection").GetComponent<Selection_slot_logic>();
        pui_script = GameObject.Find("Player").GetComponent<Picking_up_items>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (Selection_slotsm.contained_Item == null && contained_Item != null)
            {
                Selection_slotsm.change_Item(contained_Item);
                Selection_slotsm.set_quant(quant_Item);
                set_quant(0);
                Selection_slotl.Prev_slot = transform.GetComponent<slotManagerInv>();
            }
            else if (Selection_slotsm.contained_Item != null)
            {
                if (contained_Item == Selection_slotsm.contained_Item)
                {
                    if (Selection_slotsm.quant_Item == 20 || quant_Item == 20 && Selection_slotsm.quant_Item != quant_Item)
                    {
                        int temp = Selection_slotsm.quant_Item;
                        Selection_slotsm.quant_Item = quant_Item;
                        quant_Item = temp;
                    }
                    else if(quant_Item < 20)
                    {
                        int quant_toAdd = pui_script._place_checker_helper(transform, Selection_slotsm.contained_Item, Selection_slotsm.quant_Item);
                        Selection_slotsm.quant_Item -= quant_toAdd;
                        add_quant(quant_toAdd);
                    }
                }
                else if (contained_Item == null)
                {
                    change_Item(Selection_slotsm.contained_Item);
                    set_quant(Selection_slotsm.quant_Item);
                    Selection_slotsm.quant_Item = 0;
                    Selection_slotsm.contained_Item = null;
                }
                else
                {
                    Debug.Log("different items");
                }
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (Selection_slotsm.contained_Item == null && contained_Item != null)
            {
                Selection_slotsm.change_Item(contained_Item);
                int half = (int)Mathf.Ceil((float)quant_Item / 2);
                Selection_slotsm.set_quant(half);
                quant_Item -= half;
            }
            else if (Selection_slotsm.contained_Item != null)
            {
                if (contained_Item == null)
                    change_Item(Selection_slotsm.contained_Item);
                int quant_toAdd = pui_script._place_checker_helper(transform, Selection_slotsm.contained_Item, 1);
                Selection_slotsm.quant_Item -= quant_toAdd;
                add_quant(quant_toAdd);
            }
        }
        Selection_slotsm.Display_Update();
        Display_Update();
    }
}
