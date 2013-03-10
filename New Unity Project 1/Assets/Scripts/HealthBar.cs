using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this script should maniputlate a GUIskin to display a healthbar
public class HealthBar : MonoBehaviour {
    public OTAnimatingSprite healthUnit;
    public OTObject bar;
    public int maxHealth;
    private OTAnimatingSprite[] healthBar;
    private int curHealth;
    private float unitsX;
    private float unitsY;

    void Awake()
    {
      if(bar!=null && healthUnit!=null)
        initializeHealthBar();
       unitsY = 2 * OT.view.customSize;
       unitsX = unitsY * 4 / 3; //4:3 ratio
    }

    private void initializeHealthBar()
    {

        setBarPos();      
        //make n number of health units
        healthBar = new OTAnimatingSprite[maxHealth];
        curHealth = maxHealth;
        for (int i = 0; i < maxHealth; i++)
        {
            OTAnimatingSprite hUnit = (OTAnimatingSprite)Instantiate(healthUnit);
            hUnit.transform.parent = bar.transform;
            healthBar[i]=hUnit;
        }
        //fill it in a container

    }

    //todo manipulate guiskin to display health bar
    private void setBarPos()
    {
        //set position of container           
        Vector3 cornerPos = new Vector3(transform.position.x - unitsX / 2+1, transform.position.y + unitsY / 2-1,bar.depth);
        Vector3 curBarPos = bar.transform.position;
     
        bar.gameObject.transform.Translate((cornerPos-curBarPos)*Time.deltaTime*5f);
     
    }

    void decreaseHealth()
    {
        //should manipulate gui health units
        healthBar[curHealth].gameObject.SetActive(false);
        if (curHealth > 0)
            curHealth--;       
    }
    void increaseHealth()
    {    
        if(curHealth<maxHealth)
            curHealth++;
        healthBar[curHealth].gameObject.SetActive(true);
    }
    void increaseHealthTotal()
    {
        maxHealth++;
        initializeHealthBar();
    }

    // Use this for initialization
    void Start()
    {
        
	}
	
	// Update is called once per frame
	void Update () {
        setBarPos();
	}
}
