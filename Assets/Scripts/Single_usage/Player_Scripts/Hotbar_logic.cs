using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar_logic : MonoBehaviour
{
    Player_attributes_handler attr_instance;

    public slotManagerInv hotbar_slot;

    Item last_held;

    bool SpamPreventBool;

    int Slot_selected = 0;

    public Transform pov_hldr;

    private void Start()
    {
        attr_instance = transform.parent.parent.GetComponent<Player_attributes_handler>();
        hotbar_slot = transform.GetChild(Slot_selected).GetComponent<slotManagerInv>();
        Display_update(true);
    }

    private void Update()
    {
        if (!attr_instance.inMenu)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hotbar_slot.contained_Item != null)
                {
                    if (hotbar_slot.contained_Item is Tool && !SpamPreventBool)
                    {
                        SpamPreventBool = true;
                        StartCoroutine(StopSpam());
                        hotbar_slot.contained_Item.Use();
                        pov_hldr.GetChild(0).GetComponent<ToolSwing>().check_col = true;
                    }
                    else if (!(hotbar_slot.contained_Item is Tool))
                    {
                        if (hotbar_slot.contained_Item.Use())
                            hotbar_slot.remove_Use();
                    }
                }
            }
        }
        pov_holder_update();
    }

    void pov_holder_update()
    {
        slotManagerInv hbar_slot = transform.GetChild(Slot_selected).GetComponent<slotManagerInv>();
        if (pov_hldr.childCount != 0 && (last_held != hbar_slot.contained_Item || hbar_slot.contained_Item == null))
        {
            GameObject.Destroy(pov_hldr.GetChild(0).gameObject, 0);
        }
        if (pov_hldr.childCount == 0)
        {
            if (hbar_slot.contained_Item != null)
            {
                GameObject item_held = Instantiate(hbar_slot.contained_Item.prefab, new Vector3(0, 0, 0), Quaternion.identity);
                item_held.transform.SetParent(pov_hldr);
                item_held.transform.localPosition = new Vector3(0, -item_held.transform.lossyScale.y / 2, 0);
                item_held.transform.localRotation = Quaternion.Euler(0, 0, 0);
                if (item_held.GetComponent<Rigidbody>() != null)
                {
                    item_held.GetComponent<Rigidbody>().useGravity = false;
                    item_held.GetComponent<Rigidbody>().isKinematic = true;
                }
                last_held = hbar_slot.contained_Item;
            }
        }
    }

    void Display_update(bool display_state)
    {
        transform.GetChild(Slot_selected).GetChild(0).gameObject.SetActive(display_state);
    }

    public void Set_selection(int x)
    {
        if (!attr_instance.inMenu)
        {
            Display_update(false);
            Slot_selected = x;
            Display_update(true);
            hotbar_slot = transform.GetChild(Slot_selected).GetComponent<slotManagerInv>();
        }
    }

    public void Selection_numberUp()
    {
        if (!attr_instance.inMenu)
        {
            Display_update(false);
            if (Slot_selected != 9)
                Slot_selected++;
            else
                Slot_selected = 0;
            Display_update(true);
            hotbar_slot = transform.GetChild(Slot_selected).GetComponent<slotManagerInv>();
        }
    }

    public void Selection_numberDown()
    {
        if (!attr_instance.inMenu)
        {
            Display_update(false);
            if (Slot_selected != 0)
                Slot_selected--;
            else
                Slot_selected = 9;
            Display_update(true);
            hotbar_slot = transform.GetChild(Slot_selected).GetComponent<slotManagerInv>();
        }
    }

    public Item Get_held_item()
    {
        return hotbar_slot.contained_Item;
    }

    public slotManagerInv Get_current_slot()
    {
        return hotbar_slot.GetComponent<slotManagerInv>();
    }

    IEnumerator StopSpam()
    {
        yield return new WaitForSeconds(1f);
        SpamPreventBool = false;
        StopCoroutine(StopSpam());
    }
}
