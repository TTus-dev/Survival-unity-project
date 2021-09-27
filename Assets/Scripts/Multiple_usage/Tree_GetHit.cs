using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_GetHit : GetHitByTool
{
    Picking_up_items Pui;

    public List<Item> drop_items;

    public Item[] possible_drops;

    private void Start()
    {
        Pui = GameObject.Find("Player").GetComponent<Picking_up_items>();
        Generate_drops();
        hits_left = drop_items.Count;
    }

    private void Generate_drops()
    {
        for (int i = 1; i < 6; i++)
            drop_items.Add(possible_drops[Random.Range(0,2)]);
    }

    public override void GetHit()
    {
        int rand_drop = Random.Range(0, drop_items.Count);
        Pui.insert_Item(drop_items[rand_drop], 1);
        drop_items.RemoveAt(rand_drop);
        base.GetHit();
    }
}
