using UnityEngine;
using System.Collections;

public class guiscript : MonoBehaviour {

    public GUISkin MenuSkin;
    bool toggleTxt;
    int toolbarInt = 0;
    string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3" };
    int selGridInt = 0;
    string[] selStrings = { "Grid 1", "Grid 2", "Grid 3", "Grid 4" };
    float hSliderValue = 0.0f;
    float hSbarValue;

    void onGUI()
    {
        GUI.skin = MenuSkin;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300));
        GUI.Box(new Rect(0, 0, 300, 300), "This is the title of a box");
        GUI.Button(new Rect(0, 25, 100, 20), "I am a button");
        GUI.Label(new Rect(0, 50, 100, 20), "I'm a Label!");
        toggleTxt = GUI.Toggle(new Rect(0, 75, 200, 30), toggleTxt, "I am a toggle button");
        toolbarInt = GUI.Toolbar(new Rect(0, 110, 250, 25), toolbarInt, toolbarStrings);
        selGridInt = GUI.SelectionGrid(new Rect(0, 160, 200, 40), selGridInt, selStrings, 2);
        hSliderValue = GUI.HorizontalSlider(new Rect(0, 210, 100, 30), hSliderValue, 0.0f, 1.0f);
        hSbarValue = GUI.HorizontalScrollbar(new Rect(0, 230, 100, 30), hSbarValue, 1.0f, 0.0f, 10.0f);
        GUI.EndGroup();

    }
}
