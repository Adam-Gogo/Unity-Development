using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHazard : MonoBehaviour
{
    [SerializeField]
    playerMovement player;

    public float leftX;
    public float rightX;
    public float speed;

    bool facingRight = true;

    public void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
        if ((transform.position.x <= leftX && facingRight == false) || (transform.position.x >= rightX && facingRight == true))
        {
            transform.rotation = Quaternion.Euler(rot);
            facingRight = !facingRight;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() == player)
        {
            player.LoseHealth();
        }
    }

}
