using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject NewEnemy;
    private int lane;
    private float SpawnInterval = 3f;

    private Vector3 l1 = new Vector3(2.2f, 1f, 1);
    private Vector3 l2 = new Vector3(2.2f, 1f, 3);
    private Vector3 l3 = new Vector3(2.2f, 1f, 5);
    private Vector3 l4 = new Vector3(2.2f, 1f, 7);
    private bool MakeMore = true;

    private float _NextSpawn;

	// Use this for initialization
	void Start () {
        _NextSpawn = Time.time + SpawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= _NextSpawn)
        {
            lane = Random.Range(1, 9);
            if (lane < 3)
                Instantiate(NewEnemy, l1, Quaternion.identity);
            else if (lane < 5)
                Instantiate(NewEnemy, l2, Quaternion.identity);
            else if (lane < 7)
                Instantiate(NewEnemy, l3, Quaternion.identity);
            else
                Instantiate(NewEnemy, l4, Quaternion.identity);
            _NextSpawn = Time.time + SpawnInterval;
        }
    }



}
