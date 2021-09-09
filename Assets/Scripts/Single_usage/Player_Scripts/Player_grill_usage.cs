using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_grill_usage : In_inv
{
    Crosshair_dialog_handler cdial;

    Player_attributes_handler pattr;

    Hotbar_logic hbl;

    public Item fuel;

    Transform slot = null;
    Transform aimed_object;

    Camera cam;

    private new void Start()
    {
        base.Start();
        cam = transform.Find("Player_cam").GetComponent<Camera>();
        cdial = GetComponent<Crosshair_dialog_handler>();
        pattr = GetComponent<Player_attributes_handler>();
        hbl = hotbar.GetComponent<Hotbar_logic>();
    }

    private void Update()
    {
        Ray cam_ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cam_ray, out RaycastHit hit) && hit.distance < pattr.aiming_distance)
        {
            Grill_Logic tsl;
            aimed_object = hit.transform;
            if (aimed_object.CompareTag("Fuel"))
            {
                tsl = aimed_object.GetComponentInParent<Grill_Logic>();
                if (tsl != null)
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
                        slot = null;
                    }
                    if (slot == null)
                    {
                        for (i = 0; i < 14; i++)
                        {
                            slot = inv.GetChild(i);
                            if (slot.GetComponent<slotManager>().contained_Item == fuel)
                            {
                                cdial.Set_cdialog("Dodaj drewna");
                                cdial.Set_dialog_color(Color.black);
                                break;
                            }
                        }
                        slot = null;
                    }
                    if (tsl.fuel_state < 3)
                    {
                        cdial.Enablestate(true);
                        if (Input.GetKeyDown(KeyCode.E) && slot != null)
                        {
                            slot.GetComponent<slotManager>().change_quant(-1);
                            tsl.IncreaseFuel();
                        }
                        else if (Input.GetKeyDown(KeyCode.R))
                            tsl.DecreaseFuel();
                    }
                    else if (tsl.fuel_state == 3)
                        cdial.Enablestate(false);
                }
            }
            else if (aimed_object.CompareTag("Grill_top"))
            {
                if (hbl.Get_held_item() is Cookable)
                {
                    tsl = aimed_object.GetComponentInParent<Grill_Logic>();
                    cdial.Set_cdialog("Po³ó¿ jedzenie");
                    cdial.Set_dialog_color(Color.black);
                    cdial.Enablestate(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        bool add_check = tsl.Add_cookable(hbl.Get_held_item() as Cookable);
                        if (add_check)
                            hbl.Get_current_slot().change_quant(-1);
                    }
                }
                else
                    cdial.Enablestate(false);
            }
        }
        else { cdial.Enablestate(false); }
    }
}
