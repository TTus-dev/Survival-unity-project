using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craftable : Item
{
    public struct CandQ
    {
        Item comp;
        int quant;
    }
    public CandQ[] Components;
}
