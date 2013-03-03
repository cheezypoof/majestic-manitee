using UnityEngine;
using System.Collections;

public class KentController : MonoBehaviour {
    public OTAnimatingSprite staticBlock;
    public OTAnimatingSprite attackBlock;
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
    private CurrentDirection curDir;

    enum CurrentDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        UPLEFT,
        UPRIGHT,
        DOWNLEFT,
        DOWNRIGHT
    };
  
	// Use this for initialization
	void Start () {
        jumping = false;
        grounded = false;
        sprite = GetComponent<OTSprite>();
        sprite.onCollision = OnCollision;
        //attackBlock.gameObject.SetActive(false);
        //camera follow player
        OT.view.movementTarget = gameObject;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}
	
	
    void Update()
    {
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
                    rigidbody.AddForce(Vector3.up * jumpVel * 2, ForceMode.Impulse);
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
        curDir = getCurDirection();

        if (Input.GetKeyDown("z"))
        {
            spawnBlock(curDir);
        }
        if (Input.GetKeyDown("x"))
        {
            StartCoroutine(dash(curDir));

        }
        if (Input.GetKeyDown("c"))
        {
            attack(curDir);

        }

        float direction = Input.GetAxis("Horizontal");
        float amtToMove = direction * PlayerSpeed * Time.deltaTime;
        transform.Translate(new Vector3(amtToMove, 0f, 0f));

        updateRaycasts();
       
    }

    CurrentDirection getCurDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0 && vertical > 0)
            curDir = CurrentDirection.UPRIGHT;
        else if (horizontal < 0 && vertical > 0)
            curDir = CurrentDirection.UPLEFT;
        else if (horizontal > 0 && vertical < 0)
            curDir = CurrentDirection.DOWNRIGHT;
        else if (horizontal < 0 && vertical < 0)
            curDir = CurrentDirection.DOWNLEFT;
        else if (horizontal > 0)
            curDir = CurrentDirection.RIGHT;
        else if (horizontal < 0)
            curDir = CurrentDirection.LEFT;
        else if (vertical < 0)
            curDir = CurrentDirection.DOWN;
        else if (vertical > 0)
            curDir = CurrentDirection.UP;

        return curDir;
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
             //jumping = false;
             //jumpNum = 0;
            // jumpctrl = 0;
         }
         if (Physics.Raycast(transform.position, Vector3.right, 0.5f,groundMask))
         {
             //Debug.Log("ground ray" + transform.position.ToString());
             transform.Translate(new Vector3(-0.1f, 0f, 0f));
            // jumping = false;
             //jumpNum = 0;
            // jumpctrl = 0;
         }

     }

    void spawnBlock(CurrentDirection direction)
    { 
        Vector3 blockPos = dirVector(direction,1);     
        blockMaker.spawnBlock(blockPos);
        
    }
    void attack(CurrentDirection direction)
    {
        //spawn animated attack block in direction and damage damagable things
        attackBlock.gameObject.SetActive(true);
        attackBlock.position = dirVector(direction, 1);
        attackBlock.onAnimationFrame = trackPosDelegate;
        attackBlock.Play();
        attackBlock.onAnimationFinish =attackFinishedDelegate;
       // attackBlock.gameObject.SetActive(false);
      
    }
    void trackPosDelegate(OTObject obj)
    {
        obj.position = dirVector(curDir, 1);
    }
    void attackFinishedDelegate(OTObject obj)
    {
       obj.gameObject.SetActive(false);
    }

    //gives a vector3 n units away from kent in a direction
    Vector3 dirVector(CurrentDirection direction, int unit)
    {    
        float xDir = transform.position.x;
        float yDir = transform.position.y;
        switch (direction)
        {
            case CurrentDirection.UP:
                yDir += unit;
                break;
            case CurrentDirection.DOWN:
                yDir -= unit;
                break;
            case CurrentDirection.LEFT:
                xDir -= unit;
                break;
            case CurrentDirection.RIGHT:
                xDir += unit;
                break;
            case CurrentDirection.UPLEFT:
                xDir -= unit;
                yDir += unit;
                break;
            case CurrentDirection.UPRIGHT:
                xDir += unit;
                yDir += unit;
                break;
            case CurrentDirection.DOWNRIGHT:
                xDir += unit;
                yDir -= unit;
                break;
            case CurrentDirection.DOWNLEFT:
                xDir -= unit;
                yDir -= unit;
                break;
            default:
                break;
        }
        return new Vector3(xDir, yDir, 0f);
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
