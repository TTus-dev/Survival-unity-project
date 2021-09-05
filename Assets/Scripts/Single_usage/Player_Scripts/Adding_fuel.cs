using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adding_fuel : In_inv
{
    Crosshair_dialog_handler cdial;

    Camera cam;

    Player_attributes_handler pattr;

    public Item fuel;

    Transform slot = null;
    Transform aimed_object;

    private new void Start()
    {
        base.Start();
        cam = transform.Find("Player_cam").GetComponent<Camera>();
        cdial = GetComponent<Crosshair_dialog_handler>();
        pattr = GetComponent<Player_attributes_handler>();
    }

    private void Update()
    {
        Ray cam_ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cam_ray, out RaycastHit hit) && hit.distance < pattr.aiming_distance)
        {
            aimed_object = hit.transform;
            if (aimed_object.CompareTag("Fuel"))
            {
                cdial.Set_cdialog("Brak drewna w ekwipunku");
                cdial.Set_dialog_color(new Color(181, 0, 0, 255));
                int i;
                for (i = 0; i < 10; i++)
                {
                    slot = hotbar.GetChild(i);
                    if (slot.GetComponent<slotManager>().contained_Item == fuel)
                    {
                        cdial.Set_cdialog("Dodaj drewna");
                        cdial.Set_dialog_color(Color.black);
                        break;
                    }
                }
                for (i = 0; i < 14; i++)
                {
                    slot = inv.GetChild(i);
                    if (slot.GetComponent<slotManager>().contained_Item == fuel)
                    {
                        cdial.Set_cdialog("Dodaj drewna");
                        cdial.Set_dialog_color(Color.black);
                        break;
                    }
                    slot = null;
                }
                cdial.Enablestate(true);
                if (Input.GetKeyDown(KeyCode.E) && slot != null)
                {
                    Debug.Log(slot.name);
                    slot.GetComponent<slotManager>().change_quant(-1);
                }
            }
        }
        else { cdial.Enablestate(false); }
    }
}
