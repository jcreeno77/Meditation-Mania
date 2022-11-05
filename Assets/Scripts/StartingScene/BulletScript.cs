using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float decayTimer = 0f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        decayTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += transform.right * 10 * Time.deltaTime;
        decayTimer += Time.deltaTime;
        
        if(decayTimer >= 4f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if(collision.gameObject.tag == "Thought")
        {
            if (collision.gameObject.GetComponent<thoughtMovement>().clicked == true)
            {
                Destroy(collision.gameObject);
                
            }
        }
    }
}
