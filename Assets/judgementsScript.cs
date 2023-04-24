using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgementsScript : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        float xVal = Random.Range(-5, 5);
        float yVal = Random.Range(5.5f, 7);
        float scale = .5f;
        transform.localScale = new Vector3(transform.localScale.x * scale, transform.localScale.y * scale, transform.localScale.z * scale);

        transform.position = new Vector3(xVal, yVal, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 4f)
        {
            Destroy(gameObject);
        }
    }
}
