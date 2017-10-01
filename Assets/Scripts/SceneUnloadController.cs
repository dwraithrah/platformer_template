using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUnloadController : MonoBehaviour {

    bool unloaded;  //to unload scene if not unloaded yet

    void Awake()
    {
        if (!unloaded)//if previous scene has not been unloaded, unload it
        {
            unloaded = true;

            DataHolderController.anymanager.UnloadScene(1);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
