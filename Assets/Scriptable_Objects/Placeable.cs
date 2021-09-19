using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_PlaceableItem", menuName = "Items/Craftable/Placeable")]
public class Placeable : Craftable
{
    Transform cam_spawn;

    public GameObject placed_prefab;

    public new void OnEnable()
    {
        base.OnEnable();
        cam_spawn = player_reference.transform.Find("Player_cam");
    }

    public override bool Use()
    {
        GameObject a = new GameObject();
        if (Physics.Raycast(cam_spawn.position, cam_spawn.forward, out RaycastHit t_hit, 5) && t_hit.collider.gameObject.layer == 8)
        {
            if (t_hit.point != null)
            {
                a = Instantiate(placed_prefab, t_hit.point, new Quaternion());
                return true;
            }
        }
        return false;
    }
}
