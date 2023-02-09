using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        playerMovement p = other.gameObject.GetComponent<playerMovement>();
        if(p != null && p.getHealth() < 3)
        {
            p.GainHealth();
            Destroy(gameObject);
        }
    }

}
