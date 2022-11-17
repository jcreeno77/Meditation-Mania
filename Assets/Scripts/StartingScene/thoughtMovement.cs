using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thoughtMovement : MonoBehaviour
{
    [SerializeField] GameObject centerObject;
    [SerializeField] GameObject placeHoldCube;
    [SerializeField] GameObject sequenceController;
    [SerializeField] float baseScale;
    [SerializeField] float clickedScale;

    [SerializeField] AudioClip[] thoughtClips;
    AudioClip mainClip;
    bool thoughtPlayed = false;
    
    GameObject holdCube;
    public bool clicked;
    public bool cooldown = false;

    public bool thoughtInSequence = false;
    private Color[] colorListThot;
    private float cooldownTimer;
    private float freezeTimer;
    Vector3 mainDirection;
    bool inside = false;
    bool firstClick = false;
    Animator anim;
    private Color mainVal;
    private Color transitionVal = new Color(155f/255f,114f / 255f, 242f / 255f);
    
    // Start is called before the first frame update
    void Start()
    {
        centerObject = GameObject.FindGameObjectWithTag("center");
        sequenceController = GameObject.FindGameObjectWithTag("seqController");
        clicked = false;
        anim = GetComponent<Animator>();

        colorListThot = new Color[3]{new Color(242f/255f,116f / 255f, 5f / 255f), new Color(242f / 255f, 159f / 255f, 5f / 255f), new Color(242f / 255f, 183f / 255f, 5f / 255f)};
        int randVal = Random.Range(0, 2);
        mainVal = colorListThot[randVal];
        GetComponent<SpriteRenderer>().color = mainVal;

        //chooses thought soundclip
        int lenthoughtClips = thoughtClips.Length;
        int randThoughtVal = Random.Range(0, lenthoughtClips - 1);
        mainClip = thoughtClips[randThoughtVal];
    }

    // Update is called once per frame
    void Update()
    {
        if (thoughtInSequence)
        {
            freezeTimer = 0f;
        }
        //CENTER FUNCTIONALITY
        float distanceToCenter = Vector3.Distance(transform.position, centerObject.transform.position);
        //CHECKS IF IN CENTER
        if(distanceToCenter < 3.4 && !inside)
        {
            holdCube = Instantiate(placeHoldCube);
            holdCube.transform.position = transform.position;
            holdCube.transform.parent = centerObject.transform;
            inside = true;
        }

        if (inside)
        {
            //INSIDE FUNCTIONALITY
            mainDirection = transform.position - holdCube.transform.position;
            transform.position -= mainDirection * Time.deltaTime * .5f;


        }
        else
        {
            //APPROACH FUNCTIONALITY
            //Cooldown functionality after click
            if (cooldown)
            {
                cooldownTimer += Time.deltaTime;
                if (cooldownTimer > 3f)
                {
                    cooldown = false;
                    anim.SetBool("ReAnim", true);
                }
            }
            else
            {
                cooldownTimer = 0;
            }

            //Click functionality
            if (clicked)
            {
                if (!thoughtPlayed)
                {
                    GetComponent<AudioSource>().PlayOneShot(mainClip);
                    thoughtPlayed = true;
                }
                if (!cooldown)
                {
                    //Put all clicked code here
                    //float currentScale = Mathf.Lerp(transform.localScale.x, clickedScale, Time.deltaTime*2);
                    //transform.localScale = new Vector3(currentScale, currentScale, currentScale);
                    //TRANSITION COLOR
                    float rOfRGB = GetComponent<SpriteRenderer>().color.r;
                    float rOfClickedRGB = transitionVal.r;
                    rOfRGB = Mathf.Lerp(rOfRGB, rOfClickedRGB, Time.deltaTime);
                    float gOfRGB = GetComponent<SpriteRenderer>().color.g;
                    float gOfClickedRGB = transitionVal.g;
                    gOfRGB = Mathf.Lerp(gOfRGB, gOfClickedRGB, Time.deltaTime);
                    float bOfRGB = GetComponent<SpriteRenderer>().color.b;
                    float bOfClickedRGB = transitionVal.b;
                    bOfRGB = Mathf.Lerp(bOfRGB, bOfClickedRGB, Time.deltaTime);

                    

                    freezeTimer += Time.deltaTime;
                    anim.SetBool("isClicked", true);
                    anim.SetBool("ReAnim", false);
                    if (freezeTimer > 2)
                    {
                        clicked = false;
                        cooldown = true;
                        
                        
                    }
                }
                else
                {
                    clicked = false;
                    
                }

                //IF THOUGHT IS IN INTRO SEQUENCE
                

            }
            else
            {
                anim.SetBool("ReAnim", true);
                anim.SetBool("isClicked", false);
                //float currentScale = transform.localScale.x;
                //currentScale = Mathf.Lerp(currentScale, baseScale, Time.deltaTime*2);
                //transform.localScale = new Vector3(currentScale, currentScale, currentScale);
                //TRANSITION COLOR
                float rOfRGB = GetComponent<SpriteRenderer>().color.r;
                float rOfmainVal = mainVal.r;
                rOfRGB = Mathf.Lerp(rOfRGB, rOfmainVal, Time.deltaTime);
                float gOfRGB = GetComponent<SpriteRenderer>().color.g;
                float gOfmainVal = mainVal.g;
                gOfRGB = Mathf.Lerp(gOfRGB, gOfmainVal, Time.deltaTime);
                float bOfRGB = GetComponent<SpriteRenderer>().color.b;
                float bOfmainVal = mainVal.b;
                bOfRGB = Mathf.Lerp(bOfRGB, bOfmainVal, Time.deltaTime);
                GetComponent<SpriteRenderer>().color = new Color(rOfRGB, gOfRGB, bOfRGB);
                mainDirection = transform.position - centerObject.transform.position;
                transform.position -= mainDirection * Time.deltaTime * .1f;
                freezeTimer = 0;

                thoughtPlayed = false;
            }

        }
        if (thoughtInSequence && clicked && !firstClick)
        {
            sequenceController.GetComponent<sequenceController>().thoughtSequenceClicked = true;
            //Destroy animation
            firstClick = true;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "blastRing")
        {
            Destroy(gameObject);
        }
    }
    



}
