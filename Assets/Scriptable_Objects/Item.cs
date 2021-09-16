using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string item_name;
    public GameObject prefab;
    public Sprite inventory_icon;
    public int max_uses = 1;
    public int max_stack;
    public GameObject player_reference;

    public void OnEnable()
    {
        player_reference = GameObject.Find("Player");
    }

    public virtual bool Use()
    {
        throw new System.NotImplementedException();
    }
}
