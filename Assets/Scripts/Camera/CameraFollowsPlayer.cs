using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public GameObject player; // The player object.

    void Start() {
        // Get the player object.
        player = GameObject.Find("Player");
    }

    void Update() {
        // Grab the player's X position.
        float playerX = player.transform.position.x;
        
        // Grab the player's Y position.
        float playerY;
        if(player.transform.position.y < 0) {
            playerY = 0;
        }
        else {
            playerY = player.transform.position.y;
        }

        // Set the camera's position to the player's position.
        setCameraPosition(playerX, playerY);
    }

    void setCameraPosition(float x, float y) {
        // Set the camera's position to the player's position.
        transform.position = new Vector3(x, y, -10);
    }
}
