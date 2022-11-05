using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{
    public delegate void showBreath();
    public static event showBreath onTimerEnd;
    float timer;
    bool timerEnd;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        timerEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 7.5 && !timerEnd)
        {
            if (onTimerEnd != null)
            {
                onTimerEnd();
                timerEnd = true;
            }
        }
    }
}
