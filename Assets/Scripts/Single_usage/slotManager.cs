using UnityEngine;
using UnityEngine.UI;

public class slotManager : MonoBehaviour
{
    public Item contained_Item;
    public int quant_Item;
    public int current_uses;

    public bool TurnOffUpdate;

    protected Transform qnt;
    protected Transform its;

    protected void Start()
    {
        qnt = transform.Find("Quantity");
        its = transform.Find("Item_image");
        if (TurnOffUpdate)
        {
            its.GetComponent<Image>().sprite = contained_Item.inventory_icon;
            its.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (!TurnOffUpdate)
            Display_Update();
    }

    public void exchange(slotManager s)
    {
        int temp_quant = s.quant_Item;
        int temp_uses = s.current_uses;
        Item temp_contained = s.contained_Item;
        s.quant_Item = quant_Item;
        s.change_Item(contained_Item);
        s.current_uses = current_uses;
        quant_Item = temp_quant;
        change_Item(temp_contained);
        current_uses = temp_uses;
    }

    public void change_Item(Item x)
    {
        contained_Item = x;
        if (contained_Item != null)
            Debug.Log(its == null);
            its.GetComponent<Image>().sprite = contained_Item.inventory_icon;
    }

    public void set_quant(int n)
    {
        quant_Item = n;
    }

    public void change_quant(int n)
    {
        quant_Item += n;
    }

    public void Display_Update()
    {
        if (quant_Item == 0)
            contained_Item = null;
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
            else if (quant_Item <= 1)
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
