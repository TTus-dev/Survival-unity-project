using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_EdibleItem", menuName = "Items/Edible")]
public class Edible : Item
{
    public float nutrive_value;
    public float thrist_value;

    public override void Use()
    {
        Player_attributes_handler pah = GameObject.Find("Player").GetComponent<Player_attributes_handler>();
        pah.change_Hunger(nutrive_value);
        pah.change_Thirst(thrist_value);
    }
}
