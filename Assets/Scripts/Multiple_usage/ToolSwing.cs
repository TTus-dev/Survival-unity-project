using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwing : MonoBehaviour
{
    public bool check_col = false;

    Hotbar_logic hbar;

    public string affected_tag;

    private void Start()
    {
        hbar = GameObject.Find("Player/Hud/Hotbar").GetComponent<Hotbar_logic>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (check_col && other.CompareTag(affected_tag))
        {
            GetHitByTool ghbt = other.GetComponent<GetHitByTool>();
            ghbt.GetHit();
            hbar.hotbar_slot.remove_Use();
            check_col = false; 
        }
    }
}
