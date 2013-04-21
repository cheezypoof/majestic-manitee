using UnityEngine;
using System.Collections;

public class ingamemenu : MonoBehaviour {

    public GUISkin myskin;
    public Texture2D background, LOGO;
    public string messageToDisplayOnClick = "About \n Press Esc to go back";

    private string clicked = "";
    private Rect optionsRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 200);

    private void OnGUI()
    {
        if (background != null)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);

        if (clicked == "" || clicked == "options")
        {
            if (LOGO != null)
                GUI.DrawTexture(new Rect(Screen.width / 2 - 250, 70, 500, 200), LOGO);
        }
        if (clicked == "")
        {

            GUI.skin = myskin;
            if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 2, 200, 30), "Play"))
            {
                Application.LoadLevel("haulslevel");
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 2 + 50, 200, 30), "Continue"))
            {

            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 2 + 100, 200, 30), "Options"))
            {
                clicked = "options";

            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 2 + 150, 200, 30), "Credits"))
            {
                clicked = "about";
            }
        }
        else if(clicked == "options")
        {
            GUI.Window(0, optionsRect, optionsFunc, "Options");
        }
        else
        {
            GUI.Box(new Rect(0,0, Screen.width,Screen.height), messageToDisplayOnClick);
        }
    }

    private void optionsFunc(int id)
    {
        GUILayout.Box("Volume");

        if(GUILayout.Button("Back"))
        {
            clicked = "";
        }

        GUI.DragWindow(new Rect(0, 0, 99999, 99999));
    }

    private void Update()
    {
        if(clicked == "about" && Input.GetKey(KeyCode.Escape))
        {
            clicked = "";
        }
    }
}
