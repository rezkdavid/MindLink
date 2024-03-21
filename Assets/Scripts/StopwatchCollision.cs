using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Diagnostics;

public class StopwatchCollision : MonoBehaviour
{
    private bool stopwatchStarted;
    private float startTime;
    private float elapsedTime;

    private void Start()
    {
        stopwatchStarted = true;
        startTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal")) // Replace "Platform" with your platform tag
        {
            stopwatchStarted = false;
            elapsedTime = Time.time - startTime;
            Debug.Log("Stopwatch Time: " + elapsedTime.ToString("0.00") + " seconds");
        }
    }

    private void Update()
    {
        if (stopwatchStarted)
        {
            elapsedTime = Time.time - startTime;
        }
    }
}
