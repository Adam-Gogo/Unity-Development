using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;

    
    public int jumpForce;

    private float horizontal;
    private float vertical;

    Rigidbody rb;

    public TMP_Text HealthCounter;

    private int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HealthCounter.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        if (health == 0)
        {
            SceneManager.LoadScene("test scene");
        }
    }

    void FixedUpdate()
    {
        Vector3 position = transform.position;

        position.x += speed * horizontal * Time.deltaTime;
        position.z += speed * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }

    public void LoseHealth()
    {
        health--;
        HealthCounter.text = "Health: " + health;
    }

}
