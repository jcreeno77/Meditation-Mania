using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breathScript : MonoBehaviour
{
    float baseIncrement;
    float FOVincrement;
    float baseCameraPOV = 60f;

    [SerializeField] GameObject CircleFill;
    [SerializeField] GameObject perfectExhale;
    public bool breathReleased = false;
    

    bool breathIn = true;
    [SerializeField] AudioClip breath1;
    [SerializeField] AudioClip breath2;
    [SerializeField] AudioClip badBreath;
    [SerializeField] AudioClip perfectBreath;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioSource audioSrc2;


    // Start is called before the first frame update
    void Start()
    {
        //Declare starting Variables
        baseIncrement = 1f;
        FOVincrement = 0f;

        //Declare components
        //audioSrc = GetComponent<AudioSource>();
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
        
        //Functionality involving breath inhale
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
            audioSrc.clip = badBreath;
            audioSrc.Play();
        }

        //functionality for breath exhale
        if (Input.GetKeyUp(KeyCode.Space) && breathIn)
        {
            

            breathIn = false;
            if (FOVincrement > 3.51)
            {
                Debug.Log("BREATH MISS");
                audioSrc.clip = badBreath;
                audioSrc.Play();
            }
            else if (FOVincrement >= 3.3 && FOVincrement <= 3.51)
            {
                //Sound stuff for breath release
                Debug.Log("NICE BREATH");
                audioSrc.clip = breath2;
                audioSrc.Play();
                audioSrc2.clip = perfectBreath;
                audioSrc2.Play();

                //Action stuff for breath release
                breathReleased = true;
                perfectExhale.SetActive(true);
            }
            else if (FOVincrement >= 2.5 && FOVincrement < 3.3)
            {
                Debug.Log("OK BREATH");
                audioSrc.clip = breath2;
                audioSrc.Play();
                breathReleased = true;
            }
            else if (FOVincrement < 2.5)
            {
                Debug.Log("BAD BREATH (Stinky!)");
                audioSrc.clip = badBreath;
                audioSrc.Play();
            }
        }

        FOVincrement = Mathf.Clamp(FOVincrement, 0, 8f);
        baseIncrement = Mathf.Clamp(baseIncrement, 1f, 50f);

        //Set objects and components to change according to changing increment
        GetComponent<Camera>().fieldOfView = baseCameraPOV + (FOVincrement*3);
        CircleFill.transform.localScale = new Vector3(.5f+ FOVincrement*.3f, .5f+ FOVincrement*.3f, CircleFill.transform.localScale.z);


    }
}
