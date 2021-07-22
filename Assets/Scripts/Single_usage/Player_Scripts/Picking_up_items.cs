using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picking_up_items : MonoBehaviour
{
    Transform pdialog;
    Transform inv;
    Transform hotbar;

    Player_attributes_handler pattr;

    struct partial_pickup_info
    {
        public Transform slot;
        public int pickeditem_no;
    }

    private void Start()
    {
        Transform hud = transform.Find("Hud");
        pdialog = hud.Find("Pick_up_dialog");
        inv = hud.Find("Inventory/Background");
        hotbar = hud.Find("Hotbar");
        pattr = GetComponent<Player_attributes_handler>();
    }

    void Update()
    {
        Camera cam = transform.Find("Player_cam").GetComponent<Camera>();
        Ray cam_ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(cam_ray, out hit) && hit.distance < 2.5f && !pattr.inMenu)
        {
            Transform aimed_object = hit.transform;
            if (aimed_object.CompareTag("Pickable"))
            {
                Item_logic dropped_item = aimed_object.GetComponent<Item_logic>();
                partial_pickup_info info = place_checker(dropped_item.scrptbl_obj, dropped_item.contained_items);
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
                        info = place_checker(dropped_item.scrptbl_obj, dropped_item.contained_items);
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
        }
        else
        {
            pdialog.gameObject.SetActive(false);
        }
    }

    public int _place_checker_helper(Transform slot, Item item, int item_ammount)
    {
        slotManager SM = slot.GetComponent<slotManager>();
        if (SM.contained_Item == item || SM.contained_Item == null)
        {
            if (SM.quant_Item + item_ammount < 21)
            {
                return item_ammount;
            }
            else if (SM.quant_Item + item_ammount > 20 && SM.quant_Item < 20)
            {
                return 20 - SM.quant_Item;
            }
        }
        return 0;
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
