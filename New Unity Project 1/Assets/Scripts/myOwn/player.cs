using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float PlayerSpeed;
    private Vector3 vel;
    private Vector3 vel2;
    private bool grounded;
    private bool isJump;
    private bool jumping;
    private float jumpctrl;
    bool isLeft;
    private int jumpNum;
    OTSprite sprite;
    float heightOfJump;
    float doubleJumpVel;
    float jumpVel;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<OTSprite>();
       sprite.onCollision = OnCollision;
        PlayerSpeed = 5f;
        doubleJumpVel = 10f;
        jumpVel = 12f;
        vel.y = 0;
        vel.x = 0;
        jumping = false;
        jumpctrl = 0;
        OT.view.movementTarget =gameObject;
	}
    
        IEnumerable Example()
        {
            Debug.Log("Started "+Time.time);
           
            yield return new WaitForSeconds(5);
            Debug.Log("finished "+Time.time);
        }
    
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(Example());
        //Debug.Log(Example());
        
           // Debug.Log(a);
        
        //OT.view.rotation+=90*Time.deltaTime;
        isJump = false;
        isLeft = false;
       
	   //movement space jump arrow keys move
          
        
        
        //transform.Translate(new Vector3(amtToMove,0f,0f));
        //rigidbody.AddForce(Vector3.right*amtToMove);
       // isJump = false;
       // vel.x = Input.GetAxis("Horizontal") * PlayerSpeed;
        //if(Input.GetKeyDown
        //if you reach the maximum height of jump zero out the y translate
        if (transform.position.y >= heightOfJump)
            jumpctrl = 0;

        if(Input.GetKeyDown("space")){
            if (!jumping)
            {
                // rigidbody.AddForce(Vector3.up * 300);
                jumping = true;
                jumpctrl = Time.deltaTime * jumpVel;
                heightOfJump = transform.position.y + jumpVel / 4.2f;
            }
            else
            {
                //double jump
                if (jumpNum == 1)
                {
                    jumpctrl += Time.deltaTime * doubleJumpVel;
                    jumpNum++;
                    heightOfJump = transform.position.y + doubleJumpVel / 4.2f;
                    //OT.view.zoom = 5;
                }
                else
                {
                    jumpctrl = 0;                  
                }
            }
          

        }
        if (Input.GetKeyDown("left"))
        {
            isLeft = true;
        }
        float amtToJump = Input.GetAxis("Jump")*jumpctrl;
        //if at top of jump zero out jumpctrl
        float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
        //Debug.Log("jump amount = " + amtToJump);

      
        
        transform.Translate(new Vector3(amtToMove, amtToJump, 0f));


    

	}

    /*void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        jumping = false;
    }*/

    void OnCollision(OTObject owner)
    {
        StartCoroutine(Example().GetEnumerator());
        jumping = false;
        jumpNum = 1;
        //Debug.Log("hi" + owner.collisionObject.name);
        OT.view.zoom = 0;
    }

    void updateMove()
    {
        vel.x = 0;
        vel.y = 0;
        if (isJump == true)
        {  
          jumping = true;
          vel.y = 100;         
        }
        if (isLeft)
            vel.x = PlayerSpeed;

        vel2 = vel * Time.deltaTime;
        transform.position += new Vector3(vel2.x, vel2.y, 0f);
    }
}
