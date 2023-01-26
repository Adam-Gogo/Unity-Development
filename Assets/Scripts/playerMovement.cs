using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public int speed;

    private float horizontal;
    private float vertical;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 500);
        }
    }

    void FixedUpdate()
    {
        Vector3 position = transform.position;

        position.x += speed * horizontal * Time.deltaTime;
        position.z += speed * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }
}
