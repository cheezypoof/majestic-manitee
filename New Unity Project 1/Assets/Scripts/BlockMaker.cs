using UnityEngine;
using System.Collections.Generic;
using System.Collections;


//handles all block instatiation and logic
public class BlockMaker:MonoBehaviour{
    public int numStaticBlocks;
    public OTAnimatingSprite staticBlock;
    public OTSprite dashingBlock;
    public OTSprite throwningBlock;
    private float screenHeight;
    private float screenWidth;
    private float cameraSize;
    private Stack<OTAnimatingSprite> blockStack;
    public ParticleSystem particle_smoke;

    public BlockMaker()
    {
        blockStack=new Stack<OTAnimatingSprite>();
    }
    void Awake()
    {
        screenHeight = Camera.main.pixelHeight;
        screenWidth = Camera.main.pixelWidth;
        cameraSize = Camera.main.orthographicSize;
        //Debug.Log("starting block");
        blockStack = new Stack<OTAnimatingSprite>();
        staticBlock.gameObject.SetActive(false);
        initializeStaticBlocks();
        particle_smoke = (ParticleSystem)Instantiate(particle_smoke);
        particle_smoke.Stop();
        particle_smoke.Clear();
    }
    void initializeStaticBlocks()
    {      
       for (int i = 0; i < numStaticBlocks; i++)
       {
        //OTAnimatingSprite newBlock = (OTAnimatingSprite)Instantiate(staticBlock, Vector3.up, Quaternion.identity);
        OTAnimatingSprite newBlock = (OTAnimatingSprite)Instantiate(staticBlock);
        blockStack.Push(newBlock);
       }
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
            //OTAnimatingSprite newblock = (OTAnimatingSprite)Instantiate(staticBlock, position, Quaternion.identity);
            //newblock.position = gridPos;
           
            //instatiate block and start coroutine to make it disappear after n secs.
            
                StartCoroutine(sBlockRoutine(gridPos));
                //blockStack.Pop().position = gridPos;
            //StartCoroutine(WaitAndPrint());
            

        }
       // else
           // Debug.Log(a.Length);

    }

    IEnumerator sBlockRoutine(Vector3 pos)
    {
        if (blockStack.Count > 0)
        {
            OTAnimatingSprite block = blockStack.Pop();

            particle_smoke.Play();
            particle_smoke.transform.position = pos;
            
 
            block.gameObject.SetActive(true);
            block.position = pos;
            yield return new WaitForSeconds(2f);
            block.gameObject.SetActive(false);
            blockStack.Push(block);
        }

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
