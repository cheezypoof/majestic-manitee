using UnityEngine;
using System.Collections;
using System;

public class SlowMoCreator : MonoBehaviour
{
    public OTObject Block;
    public OTObject Player;
    private Vector3 initialPos;
    private Vector3 finalPos;
    private float xDistance;
    private float yDistance;
    private Vector3 blockPos;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //grabs the initial mouse position
        if (Input.GetMouseButtonDown(0))
        {
            initialPos = Input.mousePosition;
            Debug.Log(initialPos);
        }

        //grabs the ending mouse position
        if (Input.GetMouseButtonUp(0))
        {
            finalPos = Input.mousePosition;
            Debug.Log(finalPos);
        }

        //do some math to find out where to spawn the block (NSEW)?
        xDistance = initialPos.x - finalPos.x;
        yDistance = initialPos.y - finalPos.y;
        
        //checks if x distance is larger
        if (Math.Abs(xDistance) > Math.Abs(yDistance))
        {
            //Spawn block left of player
            if (initialPos.x > finalPos.x)
            {
                KentController kc = Player.gameObject.GetComponent<KentController>();
                kc.spawnBlock(KentController.CurrentDirection.LEFT);
                /*
                blockPos = Player.transform.position;
                blockPos.x -= 1;
                OTObject thing = (OTObject)Instantiate(Block, blockPos, Quaternion.identity);
                thing.position = blockPos;
                 */
            }

            //Spawn block right of player
            else
            {
                //do something
            }
        }
        else
        {
            //Spawn block below player
            if (initialPos.y > finalPos.y)
            {
                //do something
            }
            //spawn block above player
            else
            {
                //do something
            }
        }


        /*
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 0;

            Vector3 mousePos = camera.ScreenToWorldPoint(screenPos);
            mousePos.z = 0;

            //testing purposes
            OTObject thing = (OTObject)Instantiate(Enemy, mousePos, Quaternion.identity);
            thing.position = mousePos;
        }
         */
    }
}
