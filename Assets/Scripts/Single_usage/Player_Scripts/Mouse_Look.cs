using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{
    public Transform cam;
    public Transform pov_holder;

    public float mouse_sens_x;
    public float mouse_sens_y;

    private float xRotation = 0f;

    Player_attributes_handler pattr;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pattr = GetComponent<Player_attributes_handler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pattr.inMenu)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouse_sens_x * 100 * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouse_sens_y * 100 * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 65f);
            cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX);
        }

    }
}