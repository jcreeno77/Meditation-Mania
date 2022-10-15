using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackMousePosition : MonoBehaviour
{
    [SerializeField] GameObject cubeTest;
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
        //Debug.Log(mousePos.x);
        //Debug.Log(worldPos);
        float distanceToCamera = cubeTest.transform.position.z - transform.position.z;
        Vector3 worldPos = ray.GetPoint(15f);
        
        cubeTest.transform.position = new Vector3(worldPos.x, worldPos.y,cubeTest.transform.position.z);


    }
}
