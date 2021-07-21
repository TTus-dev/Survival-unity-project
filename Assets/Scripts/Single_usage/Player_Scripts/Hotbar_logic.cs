using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar_logic : MonoBehaviour
{
    Player_attributes_handler attr_instance;

    int Slot_selected = 0;

    private void Start()
    {
        attr_instance = transform.parent.parent.GetComponent<Player_attributes_handler>();
        Display_update(true);
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
        }
    }
}
