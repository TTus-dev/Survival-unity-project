using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_logic : MonoBehaviour
{
    public Item scrptbl_obj;
    public int contained_items = 5;

    public bool remove_count(int n)
    {
        contained_items -= n;
        if (contained_items == 0)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
