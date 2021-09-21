using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GetHit : GetHitByTool
{
    public override void GetHit()
    {
        remove_hit();
    }
}
