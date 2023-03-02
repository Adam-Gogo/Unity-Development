using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class scorePickup : MonoBehaviour
{
    public int scoreValue;

    public void OnTriggerEnter(Collider other)
    {
        playerMovement p = other.gameObject.GetComponent<playerMovement>();
        if (p != null)
        {
            p.ChangeScore(scoreValue);
            Destroy(gameObject);
        }
    }
}