using UnityEngine;
using System.Collections;

public class BlockAttack : MonoBehaviour {
    OTAnimatingSprite sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<OTAnimatingSprite>();
        //sprite.onCollision = OnCollision;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        print(other.gameObject.name);
       // OTAnimatingSprite s = (OTAnimatingSprite)other;
        if (tag.Equals("Attack"))
        {          
            sprite.PlayOnce("melt");
            print("attacked m");
        }
    }
 
    
    /*void OnCollision(OTObject other)
    {
        string tag = other.gameObject.tag;
        print(other.gameObject.name);
       // OTAnimatingSprite s = (OTAnimatingSprite)other;
        if (tag.Equals("Attack"))
        {
            sprite.PlayOnce("melt");
            print("attacked m");
        }
    }*/
}
