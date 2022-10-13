using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterParent : MonoBehaviour
{
    float rotateLoc;
    // Start is called before the first frame update
    void Start()
    {
        rotateLoc = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotateLoc += 50 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateLoc -= 50 * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotateLoc);
    }
}
