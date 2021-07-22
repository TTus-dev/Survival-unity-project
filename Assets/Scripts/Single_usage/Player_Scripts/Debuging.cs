using UnityEngine;

public class Debuging : MonoBehaviour
{
    Player_attributes_handler attr_instance;
    Hotbar_logic hbar_instance;
    Selection_slot_logic sel_slot;

    private bool inventory_opened = false;

    private void Start()
    {
        attr_instance = GetComponent<Player_attributes_handler>();
        hbar_instance = transform.Find("Hud/Hotbar").GetComponent<Hotbar_logic>();
        sel_slot = transform.Find("Hud/Inventory/Selection").GetComponent<Selection_slot_logic>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) Application.Quit();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (transform.Find("Hud/Inventory") != null)
            {
                if (inventory_opened)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    attr_instance.inMenu = false;
                    inventory_opened = false;
                    sel_slot.Reset_Selection();
                    transform.Find("Hud/Inventory").gameObject.SetActive(false);
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    attr_instance.inMenu = true;
                    inventory_opened = true;
                    transform.Find("Hud/Inventory").gameObject.SetActive(true);
                }
            }
        }

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
