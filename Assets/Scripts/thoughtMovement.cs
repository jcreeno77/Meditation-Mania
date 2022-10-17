using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thoughtMovement : MonoBehaviour
{
    [SerializeField] GameObject centerObject;
    [SerializeField] GameObject placeHoldCube;
    GameObject holdCube;
    public bool clicked;
    bool cooldown = false;
    float cooldownTimer;
    public float freezeTimer;
    Vector3 mainDirection;
    bool inside = false;
    // Start is called before the first frame update
    void Start()
    {
        centerObject = GameObject.Find("CenterShooter");
        clicked = false;

    }

    // Update is called once per frame
    void Update()
    {
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
                if (cooldownTimer > 2.5f)
                {
                    cooldown = false;
                }
            }
            else
            {
                cooldownTimer = 0;
            }

            //Click functionality
            if (clicked)
            {
                if (!cooldown)
                {
                    freezeTimer += Time.deltaTime;
                    if (freezeTimer > 1)
                    {
                        clicked = false;
                        cooldown = true;
                    }
                }
                else
                {
                    clicked = false;
                }

            }
            else
            {
                mainDirection = transform.position - centerObject.transform.position;
                transform.position -= mainDirection * Time.deltaTime * .1f;
                freezeTimer = 0;
            }

        }
    }

        
}
