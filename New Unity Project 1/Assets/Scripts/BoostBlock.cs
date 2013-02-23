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

        //todo make force based on rotation of game object
        //Quaternion rot=gameObject.transform.rotation;
        Vector3 force=Vector3.up*boostForce;
        other.rigidbody.velocity = new Vector3(0,0,0);
        other.rigidbody.AddForce(force, ForceMode.Impulse);
    }


}
