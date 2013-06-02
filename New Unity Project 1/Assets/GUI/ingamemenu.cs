using UnityEngine;
using System.Collections;

public class ingamemenu : MonoBehaviour {

    public GUISkin myskin;
    public Texture2D background, LOGO;
    public string messageToDisplayOnClick = "About \n Press Esc to go back";

    private string clicked = "";
    private Rect optionsRect = new Rect(Screen.width / 2 - 250, Screen.height / 2 - 30, 500, 200);
	


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
            if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 2, 200, 30), "", "playstyle"))
            {
                Application.LoadLevel("haulslevel");
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 2 + 50, 200, 30), "", "continuestyle"))
            {

            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 2 + 100, 200, 30), "","optionsstyle"))
            {
                clicked = "options";

            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 2 + 150, 200, 30), "","creditsstyle"))
            {
                clicked = "about";
            }
        }
        else if(clicked == "options")
        {
            GUI.Window(0, optionsRect, optionsFunc, "Penor");
			///////////////////////////////////////////////////////////////
        }
        else
        {
            GUI.Box(new Rect(0,0, Screen.width,Screen.height), messageToDisplayOnClick);
        }
    }

    private void optionsFunc(int id)
    {
		GUI.skin = myskin;
        //GUILayout.Box("Volume");
		GUI.Box(new Rect(250-210/2,30, 210, 30), "Volume");

        if(GUI.Button(new Rect(250-200/2,70,200,30),"", "backstyle"))
		//if(GUILayout.Button("","backstyle"))
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
