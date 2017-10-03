using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour {

    public GameObject inventoryImage;
    public static bool hasInventory = false;//if power up was picked up or not
    private RawImage thisImage;

    Color emptyColor = Color.black;
    Color filledColor = Color.blue;

	// Use this for initialization
	void Start () {
        thisImage = (RawImage)inventoryImage.GetComponent<RawImage>();
	 }
	
	// Update is called once per frame
	void Update () {
		
        if(hasInventory)//if the power up was picked up
        {
            thisImage.color = filledColor; //color image box blue
        }
        if(!hasInventory)
        {
            thisImage.color = emptyColor; //color image box black
        }

	}
}
