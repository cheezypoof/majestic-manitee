using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	/*// Use this for initialization
	void Start () {
        StartCoroutine(move(new Vector2(3, 0)));       
	}
	
	// Update is called once per frame
	void Update () {
       // StartCoroutine(move(new Vector2(3,0)));       
	}
    IEnumerator move(Vector2 direction)
    {
        gameObject.transform.Translate(direction);
        yield return new WaitForSeconds(9);
        gameObject.transform.Translate(-direction);
    }*/
    public Vector3 pointB;

    void Update() {

        Vector3 pointA = transform.position;
        StartCoroutine(StartMove(transform, pointA, pointB, 3.0f));
       
    
}

    IEnumerator StartMove(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        
      yield return MoveObject(thisTransform, startPos, endPos, 3.0f);

      yield return MoveObject(thisTransform, endPos, startPos, 3.0f);
    }
    
    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return new WaitForSeconds(2);
        }
    }



}
