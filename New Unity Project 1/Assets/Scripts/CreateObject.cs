using UnityEngine;
using System.Collections;

public class CreateObject : MonoBehaviour {

    public GameObject Enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonUp(1))
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 0;

            Vector3 mousePos = camera.ScreenToWorldPoint(screenPos);

            Instantiate(Enemy, mousePos, Quaternion.identity);
        }

        //if (Enemy.rigidbody.position.y < -1f)
        //    Destroy(Enemy.gameObject);
	}
}
