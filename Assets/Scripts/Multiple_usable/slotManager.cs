using UnityEngine;
using UnityEngine.UI;

public class slotManager : MonoBehaviour
{
    public Item contained_Item;
    public int quant_Item;

    Transform qnt;
    Transform its;

    protected void Awake()
    {
        qnt = transform.Find("Quantity");
        its = transform.Find("Item_image");
    }

    public void change_Item(Item x)
    {
        contained_Item = x;
        its.GetComponent<Image>().sprite = x.inventory_icon;
    }

    public void add_quant(int n)
    {
        quant_Item += n;
    }

    public void subtract_quant(int n)
    {
        quant_Item -= n;
    }

    public void Display_Update()
    {
        if (qnt != null && its != null)
        {
            if (quant_Item > 1)
            {
                qnt.GetComponent<Text>().text = quant_Item.ToString();
                if (qnt.gameObject.activeSelf != true)
                    qnt.gameObject.SetActive(true);
                if (its.gameObject.activeSelf != true)
                    its.gameObject.SetActive(true);
            }
            else if (quant_Item == 1)
            {
                if (qnt.gameObject.activeSelf != false)
                    qnt.gameObject.SetActive(false);
                if (quant_Item == 1)
                {
                    qnt.GetComponent<Text>().text = quant_Item.ToString();
                    if (its.gameObject.activeSelf != true)
                        its.gameObject.SetActive(true);
                }
                else if (quant_Item == 0)
                {
                    if (its.gameObject.activeSelf != false)
                        its.gameObject.SetActive(false);
                }
            }
        }
    }
}
