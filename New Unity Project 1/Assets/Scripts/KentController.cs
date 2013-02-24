using UnityEngine;
using System.Collections;

public class KentController : MonoBehaviour {
    public OTAnimatingSprite staticBlock;
    public float PlayerSpeed;
    public float doubleJumpVel;
    public float jumpVel;
    public float maxHeightJump;
    private float MaxHeightOfCurJump;
    private bool grounded;
    private bool jumping;
    private float jumpctrl;
    private int jumpNum;
    private OTSprite sprite;
    public BlockMaker blockMaker;

    enum CurrentDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };
  
	// Use this for initialization
	void Start () {
        jumping = false;
        grounded = false;
        sprite = GetComponent<OTSprite>();
        sprite.onCollision = OnCollision;
        
        
        //todo set up block snapping grid based on camera size


        //camera follow player
        OT.view.movementTarget = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    //movement
        //if (transform.position.y >= MaxHeightOfCurJump){
       //     jumpctrl = 0;
        //    rigidbody.velocity = new Vector3(0, -9.8f, 0);
    //}
      
        if (Input.GetKeyDown("space"))
        {
            if (!jumping)
            {
                // rigidbody.AddForce(Vector3.up * 300);
                jumping = true;
                jumpctrl = 5;
                    //Time.deltaTime * jumpVel;
                jumpNum++;
                float jumpOffset = 4.2f;
                rigidbody.velocity = new Vector3(0, 0, 0);
                rigidbody.AddForce(Vector3.up * jumpVel, ForceMode.Impulse);
              
                MaxHeightOfCurJump = transform.position.y + maxHeightJump;
            }
            else
            {
                //double jump
                if (jumpNum == 1)
                {
                    jumpctrl = 1;//+= Time.deltaTime * doubleJumpVel;
                    jumpNum++;
                    float jumpOffset = 4.2f;
                    //float vely=-1*rigidbody.velocity.y;
                    rigidbody.velocity = new Vector3(0, 0, 0);
                    rigidbody.AddForce(Vector3.up*jumpVel*2, ForceMode.Impulse);
                    MaxHeightOfCurJump = transform.position.y + maxHeightJump;
                    //OT.view.zoom = 5;
                }
                else
                {
                    jumpctrl = 0;
                }
            }
        }
       

        StartCoroutine(jumpSmoothing());

       // float amtToJump = Input.GetAxis("Jump") * jumpctrl;
       // rigidbody.AddForce(Vector3.up * jumpctrl * 50,ForceMode.Impulse);
        
        float direction = Input.GetAxis("Horizontal");
        CurrentDirection curDir;
        if (direction > 0)
            curDir = CurrentDirection.RIGHT;
        else if (direction < 0)
            curDir = CurrentDirection.LEFT;
        else
            curDir = CurrentDirection.DOWN;
        if (Input.GetKeyDown("z"))
        {
            spawnBlock(curDir);
        }
        if (Input.GetKeyDown("x"))
        {
            StartCoroutine(dash(curDir));
           
        }


        float amtToMove =direction* PlayerSpeed * Time.deltaTime;
        transform.Translate(new Vector3(amtToMove,0f,0f));// amtToJump, 0f));
        updateRaycasts();
       

	}
    IEnumerator dash(CurrentDirection curDir)
    {
        Vector3 force;
        if (curDir == CurrentDirection.LEFT)
            force = Vector3.left * 1000;
        else if (curDir == CurrentDirection.RIGHT)
            force = Vector3.right * 1000;
        else
            force = Vector3.down * 1000;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.useGravity = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        yield return new WaitForSeconds(0.1f);
        if(curDir!=CurrentDirection.DOWN)
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.useGravity = true;
        
    }
    IEnumerator jumpSmoothing()
    {
       
        if (Input.GetButton("Jump"))
        {
          
            jumpctrl /= 2;
            if (jumping)
            {
                yield return new  WaitForEndOfFrame();
                rigidbody.AddForce(Vector3.up * jumpVel * jumpctrl, ForceMode.Impulse);
                
            }
        }
       
    }
     void updateRaycasts()
     {
         int groundMask = 1 << 8;
         if (Physics.Raycast(transform.position,Vector3.left,0.5f,groundMask))
         {
             //Debug.Log("ground ray"+transform.position.ToString());
             transform.Translate(new Vector3(0.1f,0f,0f));
             jumping = false;
             jumpNum = 0;
             jumpctrl = 0;
         }
         if (Physics.Raycast(transform.position, Vector3.right, 0.5f,groundMask))
         {
             //Debug.Log("ground ray" + transform.position.ToString());
             transform.Translate(new Vector3(-0.1f, 0f, 0f));
             jumping = false;
             jumpNum = 0;
             jumpctrl = 0;
         }

     }
    void spawnBlock(CurrentDirection direction)
    {
        
        float blockPosOffset=1f;
        
        float xDir=transform.position.x;
        float yDir = transform.position.y-blockPosOffset;
        if (direction == CurrentDirection.RIGHT)
            xDir = transform.position.x + blockPosOffset;
        else if (direction == CurrentDirection.LEFT)
            xDir = transform.position.x - blockPosOffset;
        else if (direction == CurrentDirection.DOWN)
        {
           // yDir = transform.position.y - blockPosOffset;
            rigidbody.velocity = new Vector3(0, 0, 0);
        }
        Vector3 blockPos = new Vector3(xDir, yDir,0f);
        
        blockMaker.spawnBlock(blockPos);
        //Vector3 pos=transform.position;
        //OTAnimatingSprite a=(OTAnimatingSprite)GameObject.Instantiate(staticBlock,blockPos,Quaternion.identity);
        //a.position=blockPos;

        //Debug.Log(blockPos.ToString());
    }

    void OnCollision(OTObject owner)
    {
        jumping = false;
        jumpNum = 0;
        jumpctrl = 0;
        //Debug.Log("hi" + owner.collisionObject.name);
        //OT.view.zoom = 0;
    }
}
