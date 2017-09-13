using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    //the player transform. Can be modified in inspector. 
    public Transform player;

    //can set this to whatever value you want in inspector as you decide where exactly to place the camera. 
    //Note, in the update code the y-axis is turned off so camera will not change vertically. 
    public Vector3 cameraOffset;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //the camera will follow the player with a certain offset.  Y offset is turned off so camera only follows along x-axis.
        transform.position = new Vector3(player.position.x + cameraOffset.x, 0, cameraOffset.z); 
    }
}
