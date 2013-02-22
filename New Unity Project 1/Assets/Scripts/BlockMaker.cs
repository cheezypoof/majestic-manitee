using UnityEngine;
using System.Collections;



//handles all block instatiation and logic
public class BlockMaker:MonoBehaviour{
    public OTAnimatingSprite staticBlock;
    public OTSprite dashingBlock;
    public OTSprite throwningBlock;
    private float screenHeight;
    private float screenWidth;
    private float cameraSize;

    void start()
    {
        screenHeight = Camera.main.pixelHeight;
        screenWidth = Camera.main.pixelWidth;
        cameraSize = Camera.main.orthographicSize;
    }
	
	

    public void spawnBlock(Vector3 position)
    {
        //instatiate block to nearest position in grid
       
        Vector3 gridPos = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y),0f);

        int groundMask=1<<8;
        //detect if anything is in the way
        Collider[] a=Physics.OverlapSphere(gridPos,0.3f,groundMask);
        if (a.Length == 0)
        {
            OTAnimatingSprite newblock = (OTAnimatingSprite)Instantiate(staticBlock, position, Quaternion.identity);
            newblock.position = gridPos;

        }
        else
            Debug.Log(a.Length);

    }

    //gives coordinates for objects to be placed
   /* Vector3 gridPosition(Vector3 position)
    {
        float x = position.x;
        float y = position.y;

        //round coordinates

        
        return new Vector3();
    }*/

}
