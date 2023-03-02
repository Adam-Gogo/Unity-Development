using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenInput : MonoBehaviour
{
    public playerMovement player;

    public int speed;

    public int horizontal;
    public int vertical;

    public void FixedUpdate()
    {
        Vector3 position = player.transform.position;

        position.x += speed * horizontal * Time.deltaTime;
        position.z += speed * vertical * Time.deltaTime;

        player.rb.MovePosition(position);

        //vertical = 0;
        //horizontal = 0;
    }

    public void Up()
    {
        vertical = 1;
    }

    public void Down()
    {
        vertical = -1;
    }

    public void Left()
    {
        horizontal = -1;
    }

    public void Right()
    {
        horizontal = 1;
    }
}
