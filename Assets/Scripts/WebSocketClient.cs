using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WebSocketClient : MonoBehaviour
{
    WebSocket ws;
    public PlayerScript playerScript; // Reference to the PlayerScript

    void Start()
    {
        // Set up WebSocket connection
        ws = new WebSocket("ws://localhost:8766");
        Debug.Log("WebSocket connection established");
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from Server: " + e.Data);
            HandleMessage(e.Data);
        };
        ws.Connect();
    }

    void HandleMessage(string message)
    {
        if (message.Contains("left_press"))
        {
            playerScript.SetDirection(-1f); // Move left
        }
        else if (message.Contains("right_press"))
        {
            playerScript.SetDirection(1f); // Move right
        }
        else if (message.Contains("left_release") || message.Contains("right_release"))
        {
            playerScript.SetDirection(0f); // Stop moving
        }
    }

    void OnDestroy()
    {
        if (ws != null)
        {
            ws.Close();
        }
    }
}
