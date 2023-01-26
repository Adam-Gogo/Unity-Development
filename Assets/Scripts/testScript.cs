using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{

    [SerializeField]
    private int speed;

    private float horizontal;
    private float vertical;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.z = position.z + speed * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }
}
