using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHazard : MonoBehaviour
{
    [SerializeField]
    playerMovement player;

    public float pos1;
    public float pos2;
    public float speed;

    bool movingRight = true;

    [SerializeField]
    bool horizontal;

    public void Update()
    {
        if (horizontal)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
            if ((transform.position.x <= pos1 && movingRight == false) || (transform.position.x >= pos2 && movingRight == true))
            {
                transform.rotation = Quaternion.Euler(rot);
                movingRight = !movingRight;
            }
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
            if ((transform.position.z <= pos1 && movingRight == false) || (transform.position.z >= pos2 && movingRight == true))
            {
                transform.rotation = Quaternion.Euler(rot);
                movingRight = !movingRight;
            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() == player)
        {
            player.LoseHealth(1);
        }
    }

}
