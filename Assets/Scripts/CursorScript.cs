using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This scipt reanables the cursor when game over and pause menu is enabled */
public class CursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void onEnable()
	{
		Cursor.visible = true;
	}

	void onDisable()
	{
		Cursor.visible = false;
	}
}
