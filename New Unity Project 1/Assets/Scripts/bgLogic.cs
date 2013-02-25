using UnityEngine;
using System.Collections;

public class bgLogic : MonoBehaviour {
    private float xLoc;
    private float yLoc;
    public GameObject sky;

	// Use this for initialization
	void Start () {
        sky.transform.position.Set(this.transform.position.x, this.transform.position.y, 20);
	}
	
	// Update is called once per frame
	void Update () {
        xLoc = transform.position.x;
        yLoc = transform.position.y;
        sky.transform.Translate(xLoc, yLoc, 20);
	}
}
