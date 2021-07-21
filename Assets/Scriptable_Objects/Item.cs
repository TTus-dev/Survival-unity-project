using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string item_name;
    public Sprite inventory_icon;
    public float uses = 1;
}
