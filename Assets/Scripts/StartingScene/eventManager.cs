using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{
    [SerializeField] GameObject sequenceController;
    public delegate void showBreath();
    public static event showBreath onTimerEnd;

    public delegate void startEnd();
    public static event startEnd OnEndBegin;

    bool activateBreath;
    bool activateEnd;
    // Start is called before the first frame update
    void Start()
    {
        activateBreath = false;
        activateEnd = false;
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

        if (sequenceController.GetComponent<sequenceController>().end && !activateEnd)
        {
            activateEnd = true;
            if(OnEndBegin != null)
            {
                OnEndBegin();
            }
        }
    }
}
