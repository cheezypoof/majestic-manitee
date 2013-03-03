using UnityEngine;
using System.Collections;

public class bgLogic : MonoBehaviour
{
    private float xLoc;
    private float yLoc;
    public GameObject sky;
    public GameObject clouds;
    public OTFilledSprite scrollingBG;
    private Vector3 previousTrans;

    // Use this for initialization
    void Start()
    {
        scrollspeed(new Vector2(0f, 0f));
        previousTrans = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //sky.transform.position = new Vector3(transform.position.x, sky.transform.position.y, sky.transform.position.z);
        scrollingBG.transform.position = new Vector3(transform.position.x, scrollingBG.transform.position.y, scrollingBG.transform.position.z);

        //delta of camera pos
        Vector3 deltaTrans = transform.position-previousTrans;
        scrollspeed(new Vector3(deltaTrans.x,deltaTrans.y));
        

        previousTrans = transform.position;
        
    }
    void scrollspeed(Vector2 speed)
    {
        if (scrollingBG != null) 
        scrollingBG.scrollSpeed = speed;
    }
}
