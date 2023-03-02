using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    bool activated = true;

    public GameObject[] Lasers;

    [SerializeField]
    float defaultTimerValue;

    float timer;

    public void Start()
    {
        timer = defaultTimerValue;
    }
    public void Update()
    {
        if (timer <= 0)
        {
            activated = !activated;
            foreach (GameObject laser in Lasers)
            {
                laser.SetActive(activated);
            }
            timer = defaultTimerValue;
        }

        timer -= Time.deltaTime;
    }
}
