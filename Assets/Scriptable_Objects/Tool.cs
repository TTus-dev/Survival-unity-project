using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_PlaceableItem", menuName = "Items/Craftable/Tool")]
public class Tool : Craftable
{
    public string anim_name;
    
    public override bool Use()
    {
        Transform pholder = player_reference.transform.Find("Player_cam").Find("Pov_holder");
        if (pholder != null && pholder.childCount != 0)
        {
            pholder.GetChild(0).GetComponent<Animator>().Play(anim_name, -1, 0f);
            return false;
        }
        return false;
    }
}
