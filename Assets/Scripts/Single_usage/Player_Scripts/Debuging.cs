using UnityEngine;

public class Debuging : MonoBehaviour
{
    Player_attributes_handler attr_instance;
    Picking_up_items Picking_up;
    Hotbar_logic hbar_instance;
    Selection_slot_logic sel_slot;

    public Item apl;

    private void Start()
    {
        attr_instance = GetComponent<Player_attributes_handler>();
        Picking_up = GetComponent<Picking_up_items>();
        hbar_instance = transform.Find("Hud/Hotbar").GetComponent<Hotbar_logic>();
        sel_slot = transform.Find("Hud/Inventory/Selection").GetComponent<Selection_slot_logic>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) Picking_up.insert_Item(apl, 19);
        if (Input.GetKeyDown(KeyCode.Q)) Application.Quit();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (transform.Find("Hud/Inventory") != null)
            {
                if (attr_instance.inMenu)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    attr_instance.inMenu = false;
                    sel_slot.Reset_Selection();
                    transform.Find("Hud/Inventory").gameObject.SetActive(false);
                    transform.Find("Hud/Panel").gameObject.SetActive(false);
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    attr_instance.inMenu = true;
                    transform.Find("Hud/Inventory").gameObject.SetActive(true);
                    transform.Find("Hud/Panel").gameObject.SetActive(true);
                }
            }
        }
        if (!attr_instance.inMenu)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                hbar_instance.Set_selection(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                hbar_instance.Set_selection(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                hbar_instance.Set_selection(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                hbar_instance.Set_selection(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                hbar_instance.Set_selection(4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                hbar_instance.Set_selection(5);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                hbar_instance.Set_selection(6);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                hbar_instance.Set_selection(7);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                hbar_instance.Set_selection(8);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                hbar_instance.Set_selection(9);
            }

            if (Input.mouseScrollDelta.y > 0)
            {
                hbar_instance.Selection_numberUp();
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                hbar_instance.Selection_numberDown();
            }
        }
    }
}
