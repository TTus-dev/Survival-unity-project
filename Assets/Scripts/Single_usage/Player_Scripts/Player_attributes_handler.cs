using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attributes_handler : MonoBehaviour
{
    private Transform health_bar;
    private Transform thirst_bar;
    private Transform hunger_bar;

    private float pcurr_hunger, pmax_hunger, pcurr_thirst, pmax_thirst, pcurr_health, pmax_health;

    public float aiming_distance;

    public bool inMenu = false;

    private void Start()
    {
        health_bar = GameObject.Find("Hud/Health/Bar").transform;
        thirst_bar = GameObject.Find("Hud/Thirst/Bar").transform;
        hunger_bar = GameObject.Find("Hud/Hunger/Bar").transform;
        pcurr_health = pmax_health = 100;
        pcurr_thirst = pmax_thirst = 100;
        pcurr_hunger = pmax_hunger = 100;
        pcurr_thirst = 20;
        pcurr_hunger = 20;
        aiming_distance = 3f;
    }

    public void change_Health(float x)
    {
        if (pcurr_health + x > pmax_health)
            pcurr_health = pmax_health;
        else if (pcurr_health + x < 0)
            pcurr_health = 0;
        else
            pcurr_health += x;
        update_Bar(pcurr_health, pmax_health, health_bar);
    }

    public void change_Thirst(float x)
    {
        if (pcurr_thirst + x > pmax_thirst)
            pcurr_thirst = pmax_thirst;
        else if (pcurr_thirst + x < 0)
            pcurr_thirst = 0;
        else
            pcurr_thirst += x;
        update_Bar(pcurr_thirst, pmax_thirst, thirst_bar);
    }

    public void change_Hunger(float x)
    {
        if (pcurr_hunger + x > pmax_hunger)
            pcurr_hunger = pmax_hunger;
        else if (pcurr_hunger + x < 0)
            pcurr_hunger = 0;
        else
            pcurr_hunger += x;
        update_Bar(pcurr_hunger, pmax_hunger, hunger_bar);
    }

    private void update_Bar(float curr, float max, Transform bar)
    {
        float ratio = curr / max;
        bar.localScale = new Vector3(ratio, 1, 1);
    }
}
