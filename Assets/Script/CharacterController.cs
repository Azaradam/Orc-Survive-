using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterController : MonoBehaviour
{

    private Rigidbody rb;
    private Animation anim;

    public ButtonController buttonController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
    }

    void Update()
    {

        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        if (!buttonController.isPaused)
        {
            Vector3 movement = new Vector3(x, 0, y);
            rb.velocity = movement * 2.5f;

            if (x != 0 && y != 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
            }


            if (x != 0 || y != 0)
            {
                anim.Play("walk");
            }
            else
                anim.Play("idle");


        }
    }
}
