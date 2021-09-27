using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitByTool : MonoBehaviour
{
    public int hits_left;

    protected void remove_hit()
    {
        hits_left -= 1;
        if (hits_left == 0)
            Destroy(gameObject);
    }

    public virtual void GetHit() { remove_hit(); }
}
