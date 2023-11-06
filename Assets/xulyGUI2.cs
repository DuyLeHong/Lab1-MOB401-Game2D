using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xulyGUI2 : MonoBehaviour
{
    public Texture GUI_Texture;

    void OnGUI()
    {
        if (!GUI_Texture)
        {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }

        if (GUI.Button(new Rect(200, 200, 150, 50), GUI_Texture))
            Debug.Log("Clicked the button with an image");

        if (GUI.Button(new Rect(200, 270, 150, 30), "Click me 2"))
            Debug.Log("Clicked the button with text");
    }


}