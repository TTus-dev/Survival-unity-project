using UnityEngine;
using UnityEngine.EventSystems;

public class slotManagerInv : slotManager, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    slotManager Selection_slotsm;
    Selection_slot_logic Selection_slotl;
    Picking_up_items pui_script;

    Transform Hotbar;

    slotManagerInv hotbar_slot = null;

    GameObject inv;

    bool cursor_Over = false;

    private new void Start()
    {
        base.Start();
        Selection_slotsm = GameObject.Find("Player/Hud/Inventory/Selection").GetComponent<slotManager>();
        Selection_slotl = GameObject.Find("Player/Hud/Inventory/Selection").GetComponent<Selection_slot_logic>();
        pui_script = GameObject.Find("Player").GetComponent<Picking_up_items>();
        Hotbar = GameObject.Find("Player/Hud/Hotbar").transform;
        inv = GameObject.Find("Player/Hud/Inventory");
    }

    private void Update()
    {
        if (contained_Item != null && current_uses == 0)
        {
            quant_Item -= 1;
            current_uses = contained_Item.max_uses;
        }
        if (cursor_Over)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                hotbar_slot = Hotbar.GetChild(0).GetComponent<slotManagerInv>();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                hotbar_slot = Hotbar.GetChild(1).GetComponent<slotManagerInv>();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                hotbar_slot = Hotbar.GetChild(2).GetComponent<slotManagerInv>();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                hotbar_slot = Hotbar.GetChild(3).GetComponent<slotManagerInv>();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                hotbar_slot = Hotbar.GetChild(4).GetComponent<slotManagerInv>();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                hotbar_slot = Hotbar.GetChild(5).GetComponent<slotManagerInv>();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                hotbar_slot = Hotbar.GetChild(6).GetComponent<slotManagerInv>();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                hotbar_slot = Hotbar.GetChild(7).GetComponent<slotManagerInv>();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                hotbar_slot = Hotbar.GetChild(8).GetComponent<slotManagerInv>();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                hotbar_slot = Hotbar.GetChild(9).GetComponent<slotManagerInv>();
            }
            if (hotbar_slot != null)
                exchange(hotbar_slot);
            hotbar_slot = null;
        }
        Display_Update();
    }

    public void change_Item(Item x)
    {
        base.change_Item(x);
        current_uses = x.max_uses;
    }

    public void remove_Use()
    {
        current_uses -= 1;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && inv.activeSelf)
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
                        Selection_slotsm.set_quant(quant_Item);
                        set_quant(temp);
                    }
                    else if(quant_Item < 20)
                    {
                        int quant_toAdd = pui_script._place_checker_helper(transform, Selection_slotsm.contained_Item, Selection_slotsm.quant_Item);
                        Selection_slotsm.change_quant(-quant_toAdd);
                        change_quant(quant_toAdd);
                    }
                }
                else if (contained_Item == null)
                {
                    change_Item(Selection_slotsm.contained_Item);
                    set_quant(Selection_slotsm.quant_Item);
                    Selection_slotsm.set_quant(0);
                    Selection_slotsm.change_Item(null);
                }
                else if (contained_Item != Selection_slotsm.contained_Item)
                {
                    exchange(Selection_slotsm);
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
                change_quant(-half);
                Selection_slotl.Prev_slot = transform.GetComponent<slotManagerInv>();
            }
            else if (Selection_slotsm.contained_Item != null)
            {
                if (Selection_slotsm.contained_Item == contained_Item || contained_Item == null)
                {
                    if (contained_Item == null)
                        change_Item(Selection_slotsm.contained_Item);
                    int quant_toAdd = pui_script._place_checker_helper(transform, Selection_slotsm.contained_Item, 1);
                    Selection_slotsm.change_quant(-quant_toAdd);
                    change_quant(quant_toAdd);
                }
                else if (contained_Item != Selection_slotsm.contained_Item)
                {
                    exchange(Selection_slotsm);
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!cursor_Over)
            cursor_Over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (cursor_Over)
            cursor_Over = false;
    }
}
