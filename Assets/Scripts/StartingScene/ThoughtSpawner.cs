using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtSpawner : MonoBehaviour
{
    float timer = 0f;
    [SerializeField] GameObject thought;
    private float timeLimit = 6f;
    private  float rateOfTimeLimDecrease = .03f;
    public float spawnSequence;

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime * rateOfTimeLimDecrease;
        Debug.Log(timeLimit);
        timer += Time.deltaTime;
        if (timer > timeLimit){
            timer = 0f;
            int leftOrRight = Random.Range(0, 2);
            Debug.Log(leftOrRight);

            float height = Random.Range(-7, 10);
            float xVal;
            if (leftOrRight == 0)
            {
                xVal = -19f;
            }
            else
            {
                xVal = 19f;
            }

            float yVal = height;
            GameObject tempThought = Instantiate(thought);
            tempThought.transform.position = new Vector3(xVal, yVal, 0f);

        }
    }
}
