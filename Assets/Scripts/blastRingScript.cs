using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastRingScript : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            Destroy(gameObject);
        }
        float expand = Time.deltaTime * 2f;
        transform.localScale = new Vector3(transform.localScale.x+expand, transform.localScale.y+expand, transform.localScale.z+expand);
    }
}
