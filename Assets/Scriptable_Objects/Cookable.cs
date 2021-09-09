using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_EdibleItem", menuName = "Items/Edible/Cookable")]
public class Cookable : Edible
{
    public bool large;
    public float seconds_to_cook;
    public Edible equivalent;
}
