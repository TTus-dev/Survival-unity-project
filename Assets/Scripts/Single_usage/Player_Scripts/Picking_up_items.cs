using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picking_up_items : MonoBehaviour
{
    Item_logic dropped_item;
    Transform prev_aimed_object;
    Transform pdialog;
    Transform inv;
    Transform hotbar;

    struct partial_pickup_info
    {
        public Transform slot;
        public int pickeditem_no;
    }

    private void Start()
    {
        pdialog = transform.Find("Hud/Pick_up_dialog");
        inv = transform.Find("Hud/Inventory/Background");
        hotbar = transform.Find("Hud/Hotbar");
    }

    void Update()
    {
        Camera cam = transform.Find("Player_cam").GetComponent<Camera>();
        Ray cam_ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(cam_ray, out hit) && hit.distance < 2.5f)
        {
            Transform aimed_object = hit.transform;
            if (aimed_object.CompareTag("Pickable"))
            {
                dropped_item = aimed_object.GetComponent<Item_logic>();
                partial_pickup_info info = place_checker();
                Transform slot = info.slot;
                Text pdialogt = pdialog.GetComponent<Text>();
                pdialogt.text = $"{dropped_item.scrptbl_obj.item_name} ({dropped_item.contained_items})";
                if (slot == null)
                {
                    pdialogt.text += " (brak miejsca)";
                    pdialogt.color = new Color(181, 0, 0, 255);
                }
                else
                {
                    pdialogt.color = Color.black;
                }
                pdialogt.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    bool stop_pickingup = false;
                    while (!stop_pickingup)
                    {
                        info = place_checker();
                        slot = info.slot;
                        if (slot != null)
                        {
                            slotManager SM = slot.GetComponent<slotManager>();
                            if (SM.contained_Item != dropped_item.scrptbl_obj)
                                SM.change_Item(dropped_item.scrptbl_obj);
                            SM.add_quant(info.pickeditem_no);
                            SM.Display_Update();
                            stop_pickingup = dropped_item.remove_count(info.pickeditem_no);
                        }
                        if (slot == inv.GetChild(inv.childCount - 1) || slot == null)
                            break;
                    }
                }
            }
            else if (!aimed_object.CompareTag("Pickable"))
            {
                pdialog.gameObject.SetActive(false);
            }
            prev_aimed_object = aimed_object;
        }
        else
        {
            pdialog.gameObject.SetActive(false);
        }
    }

    partial_pickup_info _place_checker_helper(Transform slot)
    {
        partial_pickup_info result;
        slotManager SM = slot.GetComponent<slotManager>();
        result.slot = slot;
        result.pickeditem_no = 0;
        if (SM.contained_Item == dropped_item.scrptbl_obj || SM.contained_Item == null)
        {
            if (SM.quant_Item + dropped_item.contained_items < 21)
            {
                result.pickeditem_no = dropped_item.contained_items;
            }
            else if (SM.quant_Item + dropped_item.contained_items > 20 && SM.quant_Item < 20)
            {
                result.pickeditem_no = 20 - SM.quant_Item;
            }
        }
        return result;
    }

    partial_pickup_info place_checker()
    {
        partial_pickup_info result;
        foreach (Transform child in hotbar)
        {
            result = _place_checker_helper(child);
            if (result.pickeditem_no > 0)
                return result;
        }
        foreach (Transform child in inv)
        {
            result = _place_checker_helper(child);
            if (result.pickeditem_no > 0)
                return result;
        }
        result.slot = null;
        result.pickeditem_no = 0;
        return result;
    }
}
