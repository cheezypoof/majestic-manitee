using UnityEngine;
using System.Collections;

public class BoostBlock : SpecialLevelBlock {
    public float boostForce;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //onCollide boost other +y direction
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BoostBlock");

        //force based on rotation of game object
        
        Vector3 force=transform.up*boostForce;
        other.rigidbody.velocity = new Vector3(0,0,0);
        other.rigidbody.AddForce(force, ForceMode.Impulse);
    }


}
