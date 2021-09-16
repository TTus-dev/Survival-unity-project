using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking_up_items : In_inv
{
    Player_attributes_handler pattr;

    Dropping_items_logic drp;

    Crosshair_dialog_handler cdial;

    Camera cam;

    struct partial_pickup_info
    {
        public Transform slot;
        public int pickeditem_no;
    }

    private new void Start()
    {
        base.Start();
        cam = transform.Find("Player_cam").GetComponent<Camera>();
        pattr = GetComponent<Player_attributes_handler>();
        drp = hud.GetComponent<Dropping_items_logic>();
        cdial = GetComponent<Crosshair_dialog_handler>();
    }

    void Update()
    {
        Ray cam_ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cam_ray, out RaycastHit hit) && hit.distance < pattr.aiming_distance && !pattr.inMenu)
        {
            Transform aimed_object = hit.transform;
            if (aimed_object.CompareTag("Pickable"))
            {
                Item_logic dropped_item = aimed_object.GetComponent<Item_logic>();
                partial_pickup_info info = place_checker(dropped_item.scrptbl_obj, dropped_item.contained_items);
                Transform slot = info.slot;
                cdial.Set_cdialog($"Podnieś {dropped_item.scrptbl_obj.item_name}");
                if (dropped_item.contained_items > 1)
                    cdial.Add_text($" ({dropped_item.contained_items})");
                if (slot == null)
                {
                    cdial.Add_text(" (brak miejsca)");
                    cdial.Set_dialog_color(new Color(181, 0, 0, 255));
                }
                else
                {
                    cdial.Set_dialog_color(Color.black);
                }
                cdial.Enablestate(true);
                if (Input.GetKeyDown(KeyCode.E) && slot != null)
                {
                    insert_Item(dropped_item);
                }
            }
            cdial.Enablestate(true);
        }
        else { cdial.Enablestate(false); }
    }
    public int _place_checker_helper(Transform slot, Item item, int item_ammount)
    {
        slotManager SM = slot.GetComponent<slotManager>();
        if (SM.contained_Item == item || SM.contained_Item == null)
        {
            if (SM.quant_Item + item_ammount <= item.max_stack)
            {
                return item_ammount;
            }
            else if (SM.quant_Item + item_ammount > item.max_stack && SM.quant_Item < item.max_stack)
            {
                return item.max_stack - SM.quant_Item;
            }
        }
        return 0;
    }

    public void insert_Item(Item_logic dropped_item)
    {
        partial_pickup_info info;
        Transform slot;
        bool stop_pickingup = false;
        while (!stop_pickingup)
        {
            info = place_checker(dropped_item.scrptbl_obj, dropped_item.contained_items);
            slot = info.slot;
            if (slot != null)
            {
                slotManagerInv SM = slot.GetComponent<slotManagerInv>();
                SM.change_Item(dropped_item.scrptbl_obj);
                SM.change_quant(info.pickeditem_no);
                stop_pickingup = dropped_item.remove_count(info.pickeditem_no);
            }
            if (slot == inv.GetChild(inv.childCount - 1) || slot == null)
                stop_pickingup = true;
        }
    }

    public void insert_Item(Item script_obj, int quant)
    {
        partial_pickup_info info;
        Transform slot;
        bool stop_pickingup = false;
        while (!stop_pickingup)
        {
            info = place_checker(script_obj, quant);
            slot = info.slot;
            if (slot != null)
            {
                slotManagerInv SM = slot.GetComponent<slotManagerInv>();
                SM.change_Item(script_obj);
                SM.change_quant(info.pickeditem_no);
                quant -= info.pickeditem_no;
                if (quant == 0) stop_pickingup = true;                
            }
            if (slot == inv.GetChild(inv.childCount - 1) || slot == null)
                stop_pickingup = true;
        }
        if (quant > 0)
        {
            drp.drop_item(script_obj.prefab, quant);
        }
    }

    partial_pickup_info place_checker(Item item, int item_ammount)
    {
        partial_pickup_info pChecker_result;
        int isPlace_result;
        foreach (Transform child in hotbar)
        {
            isPlace_result = _place_checker_helper(child, item, item_ammount);
            if (isPlace_result > 0)
            {
                pChecker_result.slot = child;
                pChecker_result.pickeditem_no = isPlace_result;
                return pChecker_result;
            }
        }
        foreach (Transform child in inv)
        {
            isPlace_result = _place_checker_helper(child, item, item_ammount);
            if (isPlace_result > 0)
            {
                pChecker_result.slot = child;
                pChecker_result.pickeditem_no = isPlace_result;
                return pChecker_result;
            }
        }
        pChecker_result.slot = null;
        pChecker_result.pickeditem_no = 0;
        return pChecker_result;
    }
}
