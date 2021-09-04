using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair_dialog_handler : MonoBehaviour
{
    Transform cdialog;

    Text text_cmp;

    private void Start()
    {
        cdialog = transform.Find("Hud").Find("Pick_up_dialog");
        text_cmp = cdialog.GetComponent<Text>();
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
