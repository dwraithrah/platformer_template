using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    Text textChange;                      // Reference to the Text component.


    void Awake()
    {
        // Set up the reference.
        textChange = GetComponent<Text>();
        textChange.text = "Score: " + DataHolderController.holdScore;
        // Reset the score.

    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        textChange.text = "Score: " + DataHolderController.holdScore;
    }
}
