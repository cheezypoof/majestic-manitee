using UnityEngine;
using System.Collections;

public class bgLogic : MonoBehaviour {
    private float xLoc;
    private float yLoc;
    public GameObject sky;
    public GameObject clouds;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        sky.transform.position = new Vector3(transform.position.x, sky.transform.position.y, sky.transform.position.z);
	}
}
