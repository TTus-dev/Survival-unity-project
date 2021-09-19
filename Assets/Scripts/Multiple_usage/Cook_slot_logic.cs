using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook_slot_logic : MonoBehaviour
{
    Grill_Logic gl;

    Cookable ca_obj;

    // Start is called before the first frame update
    void Start()
    {
        gl = transform.parent.parent.GetComponent<Grill_Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start_cooking(float x)
    {
        StartCoroutine(Cook_routine(x));
    }
    
    IEnumerator Cook_routine(float x)
    {
        float ttc = x;
        while (ttc > 0f)
        {
            yield return new WaitForSeconds(.1f);
            if (gl.fuel_state > -1)
                ttc -= .1f;
        }
        Transform ca = transform.GetChild(0);
        Cookable ca_obj = ca.GetComponent<Item_logic>().scrptbl_obj as Cookable;
        GameObject cooked = Instantiate(ca_obj.equivalent.prefab, ca.position, ca.rotation, transform);
        cooked.transform.localScale = ca.localScale;
        cooked.GetComponent<Rigidbody>().useGravity=false;
        Destroy(ca.gameObject);
    }
}
