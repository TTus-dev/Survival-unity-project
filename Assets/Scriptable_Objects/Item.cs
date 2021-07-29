using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string item_name;
    public GameObject prefab;
    public Sprite inventory_icon;
    public int max_uses = 1;
    public int uses = 1;

    public virtual void Use()
    {
        throw new System.NotImplementedException();
    }
}
