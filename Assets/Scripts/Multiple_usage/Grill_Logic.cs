using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill_Logic : MonoBehaviour
{
    Transform Fuel;

    public int fuel_state;

    int[] cooking_slots_s = { -1, -1, -1, -1 };
    int[] cooking_slots_l = { -1, -1 };

    Transform top;

    // Start is called before the first frame update
    void Start()
    {
        top = transform.GetChild(4);
        Fuel = transform.Find("Fuel");
        fuel_state = -1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncreaseFuel()
    {
        if (fuel_state < 3)
        {
            fuel_state += 1;
            Fuel.GetChild(fuel_state).gameObject.SetActive(true);
        }
    }

    public void DecreaseFuel()
    {
        if (fuel_state > -1)
        {
            Fuel.GetChild(fuel_state).gameObject.SetActive(false);
            fuel_state -= 1;
        }
    }

    public bool Add_cookable(Cookable c)
    {
        if (c.large == false)
        {
            for (int i = 0; i < 4; i++)
            {
                if (cooking_slots_s[i] == -1)
                {
                    cooking_slots_s[i] = 10;
                    Vector3 cookplace_offset = top.GetChild(i).position + new Vector3(0, c.prefab.transform.lossyScale.y / 2);
                    GameObject added_c = GameObject.Instantiate(c.prefab, cookplace_offset, new Quaternion(0, 0, 0, 0));
                    added_c.transform.SetParent(top.GetChild(i));
                    added_c.GetComponent<Collider>().enabled = false;
                    added_c.GetComponent<Rigidbody>().useGravity = false;
                    return true;
                }
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                if (cooking_slots_l[i] == -1)
                {
                    if (cooking_slots_s[i] == -1 & cooking_slots_s[i + 1] == -1)
                    {
                        cooking_slots_l[i] = 1;
                        Vector3 cookplace_offset = top.GetChild(i).position + new Vector3(0, c.prefab.transform.lossyScale.y / 2);
                        GameObject added_c = GameObject.Instantiate(c.prefab, cookplace_offset, new Quaternion(0, 0, 0, 0));
                        added_c.transform.SetParent(top.GetChild(i + 4));
                        added_c.GetComponent<Collider>().enabled = false;
                        added_c.GetComponent<Rigidbody>().useGravity = false;
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
