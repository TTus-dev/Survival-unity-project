using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_inv : MonoBehaviour
{
    protected Transform inv;
    protected Transform hotbar;
    protected Transform hud;

    protected void Start()
    {
        hud = transform.Find("Hud");
        inv = hud.Find("Inventory/Background");
        hotbar = hud.Find("Hotbar");
    }
}
