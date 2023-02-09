using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWarp : MonoBehaviour
{
    public string LevelName;

    public void OnTriggerEnter(Collider other)
    {
        playerMovement p = other.gameObject.GetComponent<playerMovement>();
        if (p != null)
        {
            p.LoadScene(LevelName);
        }
    }

}
