using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breathScript : MonoBehaviour
{
    float baseIncrement;
    float FOVincrement;
    float baseCameraPOV = 70f;
    [SerializeField] GameObject cube;
    float cubeStartPoint;

    bool breathIn = true;
    public AudioClip breath1;
    public AudioClip breath2;
    AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        //Declare starting Variables
        baseIncrement = 1f;
        FOVincrement = 0f;
        cubeStartPoint = cube.transform.position.y;

        //Declare components
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Base function
        if (Input.GetKeyDown(KeyCode.Space))
        {
            baseIncrement = Mathf.Pow(2.718281f, FOVincrement);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            baseIncrement += Time.deltaTime * 10f;
            FOVincrement = Mathf.Log(baseIncrement);
            
        }
        else
        {
            //baseIncrement -= Time.deltaTime * 15f;
            FOVincrement -= Time.deltaTime * 2f;
        }
        
        //Functionality involving
        if (Input.GetKeyDown(KeyCode.Space) && FOVincrement < .5f)
        {
            breathIn = true;
            Debug.Log("Nice Intake!");
            audioSrc.clip = breath1;
            audioSrc.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("BAD Intake!");
        }

        if (Input.GetKeyUp(KeyCode.Space) && breathIn)
        {
            audioSrc.clip = breath2;
            audioSrc.Play();


            breathIn = false;
            if (FOVincrement > 3.51)
            {
                Debug.Log("BREATH MISS");
            }
            else if (FOVincrement >= 3.3 && FOVincrement <= 3.51)
            {
                Debug.Log("NICE BREATH");
            }
            else if (FOVincrement >= 2.5 && FOVincrement < 3.3)
            {
                Debug.Log("OK BREATH");
            }
            else if (FOVincrement < 2.5)
            {
                Debug.Log("BAD BREATH (Stinky!)");
            }
        }

        FOVincrement = Mathf.Clamp(FOVincrement, 0, 8f);
        baseIncrement = Mathf.Clamp(baseIncrement, 1f, 50f);
        //GetComponent<Camera>().fieldOfView = baseCameraPOV + (FOVincrement*3);
        cube.transform.position = new Vector3(cube.transform.position.x, cubeStartPoint + FOVincrement * 2, cube.transform.position.z);


    }
}
