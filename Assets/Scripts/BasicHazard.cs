using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHazard : MonoBehaviour
{
    [SerializeField]
    playerMovement player;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() == player)
        {
            player.LoseHealth();
        }
    }

}
