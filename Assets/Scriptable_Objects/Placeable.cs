using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_PlaceableItem", menuName = "Items/Placeable")]
public class Placeable : Item
{
    Transform t_spawn;

    public new void OnEnable()
    {
        base.OnEnable();
        t_spawn = player_reference.transform.Find("Player_cam");
    }

    public override void Use()
    {
        bool runonce = true;
        GameObject a = new GameObject();
        while (true)
        {
            RaycastHit t_hit = new RaycastHit();
            if (Physics.Raycast(t_spawn.position, t_spawn.forward, out t_hit, 5) && t_hit.collider.gameObject.layer == 8)
            {
                if (runonce)
                {
                    a = GameObject.Instantiate(prefab, t_hit.point, new Quaternion());
                    runonce = false;
                }
                a.transform.position = t_hit.point;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                break;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                GameObject.Destroy(a);
                break;
            }
        }
    }
}
