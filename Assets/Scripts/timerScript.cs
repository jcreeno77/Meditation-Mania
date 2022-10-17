using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerScript : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 500;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        gameObject.GetComponent<TMP_Text>().text = timer.ToString("0.");
    }
}
