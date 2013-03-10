using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {
    public float radius = 10f;
    public float power = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
    void OnCollisionEnter(Collision other)
    {
        //print("explode");
        /*Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            print(hit);
            //if (!hit)

                if (hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(power, explosionPos, radius);

        }*/
        StartCoroutine(triggerExplosion());
      
    }
    IEnumerator triggerExplosion()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        //animate then explode
        OTAnimatingSprite ani= GetComponent<OTAnimatingSprite>();
        ani.Play();
        yield return new WaitForSeconds(1f);
        
        
        foreach (Collider hit in colliders)
        {
            print(hit);
            //if (!hit)

            if (hit.rigidbody)
                hit.rigidbody.AddExplosionForce(power, explosionPos, radius);

        }
        
    }
}
