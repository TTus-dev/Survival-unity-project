using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwing : MonoBehaviour
{
    public bool check_col = false;

    private void OnTriggerStay(Collider other)
    {
        if (check_col)
        {
            GetHitByTool ghbt = other.GetComponent<GetHitByTool>();
            ghbt.GetHit();
            check_col = false; 
        }
    }
}
