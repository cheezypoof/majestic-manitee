using UnityEngine;
using System.Collections;

public class bgClouds : MonoBehaviour {
    private int cloudAmt;
    private int cloudMax;
    private double cloudSpeed;
    private Vector3 cloudPos;
    private float cloudY;
    public GameObject cloud;

	// Use this for initialization
	void Start () {
        cloudY = 4;
	    cloudPos =  new Vector3(transform.position.x + 10, cloudY, 19);
        cloudAmt = 0;
        cloudMax = 50;
        cloudSpeed = 0.5;
	}
	
	// Update is called once per frame
	void Update () {
            if (cloudAmt < cloudMax)
            {
                cloudPos.x = transform.position.x + 10;
                cloudPos.y = Random.Range(3, 9);
                Instantiate(cloud, cloudPos, Quaternion.identity);         
            }
	}
}
