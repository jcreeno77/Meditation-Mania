using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterParent : MonoBehaviour
{
    float rotateLoc;
    [SerializeField] GameObject cubeTest;
    // Start is called before the first frame update
    void Start()
    {
        rotateLoc = 0f;
    }

    // Update is called once per frame
    void Update()
    {
     /*   
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotateLoc += 50 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateLoc -= 50 * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotateLoc);
     */
        //turn to face mouse
        Vector3 lookPos = transform.position - cubeTest.transform.position;
        float singleStep = 5 * Time.deltaTime;
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, lookPos, singleStep, 0.0f);
        Quaternion rotateDirection = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateDirection, singleStep);
        
        
        
        
        
        
        //Debug.Log(transform.eulerAngles.x);
        //transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 90f, transform.eulerAngles.z);
        //transform.LookAt(cubeTest.transform);

    }
}
