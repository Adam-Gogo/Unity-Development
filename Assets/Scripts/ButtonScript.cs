using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    [SerializeField]
    float timer;

    [SerializeField]
    GameObject door;

    [SerializeField]
    Material pressed;

    bool isPressed;

    Material idle;

    private void Start()
    {
        idle = GetComponent<Renderer>().material;
    }

    void ResetMaterial()
    {
        door.SetActive(true);
        GetComponent<Renderer>().material = idle;
        isPressed = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        playerMovement p = collision.gameObject.GetComponent<playerMovement>();
        if(p!= null  && !isPressed)
        {
            door.SetActive(false);
            GetComponent<Renderer>().material = pressed;
            isPressed = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        playerMovement p = collision.gameObject.GetComponent<playerMovement>();
        if (p != null)
        {
            Invoke("ResetMaterial", timer);
        }
    }
}
