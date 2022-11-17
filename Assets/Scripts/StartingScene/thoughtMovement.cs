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
    GameObject holdCube;
    public bool clicked;
    public bool cooldown = false;

    public bool thoughtInSequence = false;

    float cooldownTimer;
    private float freezeTimer;
    Vector3 mainDirection;
    bool inside = false;
    bool firstClick = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        centerObject = GameObject.FindGameObjectWithTag("center");
        sequenceController = GameObject.FindGameObjectWithTag("seqController");
        clicked = false;
        anim = GetComponent<Animator>();
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
                Debug.Log("clicked");
                if (!cooldown)
                {
                    //Put all clicked code here
                    float currentScale = Mathf.Lerp(transform.localScale.x, clickedScale, Time.deltaTime*2);
                    transform.localScale = new Vector3(currentScale, currentScale, currentScale);
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
                float currentScale = transform.localScale.x;
                currentScale = Mathf.Lerp(currentScale, baseScale, Time.deltaTime*2);
                transform.localScale = new Vector3(currentScale, currentScale, currentScale);
                mainDirection = transform.position - centerObject.transform.position;
                transform.position -= mainDirection * Time.deltaTime * .1f;
                freezeTimer = 0;
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

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "blastRing")
        {
            Destroy(gameObject);
        }
    }

    

}
