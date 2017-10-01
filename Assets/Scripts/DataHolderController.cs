using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//There's a tutorial for switching scenes and keeping objects for those scenes.
//https://www.youtube.com/watch?annotation_id=annotation_3968548225&feature=iv&src_vid=S9h_iu4Zx5I&v=i2W5O5qxCuo
//Highly recommend everyone looks at this.

public class DataHolderController : MonoBehaviour {

    public static int holdScore;
    public static int playerHealth;
    public static DataHolderController anymanager;

    bool gameStart;  //this is to ensure that the initial load is done only once

    void Awake()
    {
        if (!gameStart)
        {
            //initial values at game start
            holdScore = 0;
            playerHealth = 5;

            anymanager = this;

            //load next scene (start of game) while keeping this object, the data holder.
            //Async means scene is loaded in background
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            gameStart = true;

        }
        
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    //function to unload scenes
    public void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload(int scene)
    {
        //will wait until end of frame to continue so there's no conflict
        yield return null;

        SceneManager.UnloadScene(scene);
    }
}
