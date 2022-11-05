using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perfectExhaleTrigger : MonoBehaviour
{
    float timePassed;

    private void OnEnable()
    {
        timePassed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if(timePassed > 2.5f)
        {
            gameObject.SetActive(false);
            
        }
    }
}
