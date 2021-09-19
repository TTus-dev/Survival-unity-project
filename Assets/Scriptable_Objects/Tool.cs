using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_PlaceableItem", menuName = "Items/Craftable/Tool")]
public class Tool : Craftable
{
    public override bool Use()
    {
        Transform pholder = player_reference.transform.Find("Player_cam").Find("Pov_holder");
        if (pholder != null && pholder.childCount != 0)
        {
            pholder.GetChild(0).GetComponent<Animator>().Play("Axe", -1, 0f);
            return false;
        }
        return false;
    }
}
