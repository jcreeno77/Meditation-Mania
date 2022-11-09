using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{
    [SerializeField] GameObject sequenceController;
    public delegate void showBreath();
    public static event showBreath onTimerEnd;
    bool activateBreath;
    // Start is called before the first frame update
    void Start()
    {
        activateBreath = false;
    }


    // Update is called once per frame
    void Update()
    {

        if (sequenceController.GetComponent<sequenceController>().breathActivate)
        {
            if (onTimerEnd != null && !activateBreath)
            {
                Debug.Log("HIT!");
                onTimerEnd();
                activateBreath = true;
            }
        }
    }
}
