using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair_dialog_handler : MonoBehaviour
{
    Transform cdialog;

    Text text_cmp;

    string[] Ignored_tags = new string[] {"Untagged"};

    Camera cam;

    private void Start()
    {
        cdialog = transform.Find("Hud").Find("Pick_up_dialog");
        text_cmp = cdialog.GetComponent<Text>();
        cam = transform.Find("Player_cam").GetComponent<Camera>();
    }

    private void Update()
    {
        Ray cam_ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(cam_ray, out hit) && hit.distance < 3f)
        {
            Transform aimed_object = hit.transform;
            for (int i = 0; i < Ignored_tags.Length; i++)
            {
                if (aimed_object.CompareTag(Ignored_tags[i]))
                {
                    Set_cdialog("");
                    Enablestate(false);
                    break;
                }
            }
        }
    }

    public void Set_cdialog(string a)
    {
        text_cmp.text = a;

    }

    public void Add_text(string a)
    {
        text_cmp.text += a;
    }

    public void Set_dialog_color(Color c)
    {
        text_cmp.color = c;
    }

    public void Enablestate(bool b)
    {
        cdialog.gameObject.SetActive(b);
    }
}
