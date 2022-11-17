using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackMousePosition : MonoBehaviour
{
    [SerializeField] GameObject cubeTest;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioClip popClip;
    Plane plane = new Plane(Vector3.up, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.tag == "Thought")
                {
                    
                    if(hit.collider.gameObject.GetComponent<thoughtMovement>().cooldown == false && hit.collider.gameObject.GetComponent<thoughtMovement>().clicked == false)
                    {
                        audioSrc.clip = popClip;
                        audioSrc.Play();
                    }
                    hit.collider.gameObject.GetComponent<thoughtMovement>().clicked = true;

                    //hit.collider.gameObject.GetComponent<thoughtMovement>().freezeTimer = 0;
                }
                
            }
        }
        //FOR AIMING MECHANIC - Now obsolete
        //Debug.Log(mousePos.x);
        //Debug.Log(worldPos);
        //float distanceToCamera = cubeTest.transform.position.z - transform.position.z;
        //Vector3 worldPos = ray.GetPoint(distanceToCamera);
        
        //cubeTest.transform.position = new Vector3(worldPos.x, worldPos.y,cubeTest.transform.position.z);


    }
}
