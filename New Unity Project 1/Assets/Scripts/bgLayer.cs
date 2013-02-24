using UnityEngine;
using System.Collections;

public class bgLayer : MonoBehaviour {
	private float xLoc;
	private float yLoc;
	public GameObject background;

	// Use this for initialization
	void Start () {
        xLoc = transform.position.x;
		yLoc = transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {
        background.transform.position.Set(xLoc, yLoc, background.transform.position.z);
	}
}
