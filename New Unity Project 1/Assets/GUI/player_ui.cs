using UnityEngine;
using System.Collections;

public class player_ui : MonoBehaviour {
	
	public int maxHealth = 100;
	public int curHealth = 100;
	
	public float healthBarHeight;
	public Texture2D jumpTexture;
	
	// Use this for initialization
	void Start () {
		healthBarHeight = Screen.height / 2;
	}
	
	// Update is called once per frame
	void Update () {
		adjustCurHealth(0);
	}
	
	void OnGUI () {
		// health bar code
		GUI.Box(new Rect(8,8,44,(Screen.height / 2)+4), "");
		GUI.Box(new Rect(10,10,40, healthBarHeight), "");
		
		
		// jump button code
		GUI.BeginGroup(new Rect(Screen.width - 110, Screen.height - 110, 100, 100));
		GUI.Box(new Rect(0, 0, 100, 100), "");
		
		if(GUI.Button(new Rect(0,0,100,100), jumpTexture))
			Debug.Log("Clicked the button with an image");	
		GUI.EndGroup();
		
	}
		
	public void adjustCurHealth(int adj) {
		curHealth += adj;
		
		if(curHealth < 0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
			
		healthBarHeight = (Screen.height / 2) * (curHealth / (float)maxHealth);
	}
}
