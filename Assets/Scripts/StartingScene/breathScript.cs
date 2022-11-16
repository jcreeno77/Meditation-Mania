using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breathScript : MonoBehaviour
{
    float baseIncrement;
    float FOVincrement;
    float baseCameraPOV = 60f;
    public float colorAlpha;
    float colorAlphaIncrease;

    [SerializeField] GameObject CircleFill;
    [SerializeField] GameObject CircleOutline;
    [SerializeField] GameObject CircleFill2;
    [SerializeField] GameObject CircleFill3;
    [SerializeField] GameObject CircleFill4;
    [SerializeField] GameObject perfectExhale;
    [SerializeField] GameObject performanceCollector;

    float rateOfChange_Inhale;
    float rateOfChange_InhaleDelta;
    float rateOfChange_Exhale;
    float rateOfChange_ExhaleDelta;
    public bool breathReleased = false;
    public bool perfectBreathBegin;
    public int perfectBreathCount;
    public bool perfectBreathComplete;


    bool breathIn = true;
    [SerializeField] AudioClip breath1;
    [SerializeField] AudioClip inhaleSound;
    [SerializeField] AudioClip breath2;
    [SerializeField] AudioClip badBreath;
    [SerializeField] AudioClip perfectBreath;
    [SerializeField] AudioClip goodBreath;
    [SerializeField] AudioClip introBrthCircSnd;
    [SerializeField] AudioClip perfectBrthTryAgain;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioSource audioSrc2;


    // Start is called before the first frame update
    void Start()
    {
        //Declare starting Variables
        baseIncrement = 1f;
        FOVincrement = 0f;
        rateOfChange_InhaleDelta = .05f;
        rateOfChange_ExhaleDelta = .005f;
        rateOfChange_Inhale = 8.5f;
        rateOfChange_Exhale = .75f;
        colorAlpha = 0f;
        colorAlphaIncrease = 0f;
        perfectBreathCount = 0;
        perfectBreathComplete = false;
        //Declare components
        //audioSrc = GetComponent<AudioSource>();
        perfectBreathBegin = false;
    }

    // Update is called once per frame
    void Update()
    {
        //rateOfChange_Inhale += Time.deltaTime * rateOfChange_InhaleDelta;
        //rateOfChange_Exhale += Time.deltaTime * rateOfChange_ExhaleDelta;

        //Base function
        if (Input.GetKeyDown(KeyCode.Space))
        {
            baseIncrement = Mathf.Pow(2.718281f, FOVincrement);
        }

        if (Input.GetKey(KeyCode.Space) && breathIn)
        {
            baseIncrement += Time.deltaTime * rateOfChange_Inhale;
            FOVincrement = Mathf.Log(baseIncrement);

        }
        else
        {
            //baseIncrement -= Time.deltaTime * 15f;
            FOVincrement -= Time.deltaTime * rateOfChange_Exhale;
        }

        //Functionality involving breath inhale
        if (Input.GetKeyDown(KeyCode.Space) && FOVincrement < .5f)
        {
            breathIn = true;
            audioSrc.volume = .8f;
            audioSrc.clip = breath1;
            //audioSrc.Play();
            audioSrc2.clip = inhaleSound;
            audioSrc2.Play();


        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("BAD Intake!");
            audioSrc.volume = .2f;
            audioSrc.clip = badBreath;
            audioSrc.Play();
        }

        //functionality for breath exhale
        if (Input.GetKeyUp(KeyCode.Space) && breathIn)
        {


            breathIn = false;
            if (FOVincrement > 3.45)
            {
                if (perfectBreathBegin)
                {
                    audioSrc.clip = perfectBrthTryAgain;
                    audioSrc.Play();
                }
                else
                {
                    Debug.Log("BREATH MISS");
                    audioSrc.clip = badBreath;
                    audioSrc.Play();
                }
                performanceCollector.GetComponent<performanceCollector>().missedBreaths += 1;

            }
            else if (FOVincrement >= 3.37 && FOVincrement <= 3.45)
            {
                //Sound stuff for breath release
                Debug.Log("Perfect BREATH");
                audioSrc.volume = 1f;
                audioSrc.clip = breath2;
                audioSrc.Play();
                audioSrc2.clip = perfectBreath;
                audioSrc2.Play();
                if (perfectBreathBegin)
                {
                    perfectBreathCount += 1;
                }

                performanceCollector.GetComponent<performanceCollector>().perfectBreaths += 1;


                //Action stuff for breath release
                breathReleased = true;
                perfectExhale.SetActive(true);
            }
            else if (FOVincrement >= 2.5 && FOVincrement < 3.37)
            {
                if (perfectBreathBegin)
                {
                    audioSrc.volume = 1f;
                    audioSrc.clip = perfectBrthTryAgain;
                    audioSrc.Play();
                }
                else
                {
                    Debug.Log("OK BREATH");
                    audioSrc.volume = 1f;
                    audioSrc.clip = breath2;
                    audioSrc.Play();
                    audioSrc2.clip = goodBreath;
                    //audioSrc2.Play();
                    breathReleased = true;
                }
                performanceCollector.GetComponent<performanceCollector>().goodBreaths += 1;

            }
            else if (FOVincrement < 2.5)
            {
                if (perfectBreathBegin)
                {
                    audioSrc.clip = perfectBrthTryAgain;
                    audioSrc.Play();
                }
                else
                {
                    Debug.Log("BAD BREATH (Stinky!)");
                    audioSrc.clip = badBreath;
                    //audioSrc.Play();
                }
                performanceCollector.GetComponent<performanceCollector>().missedBreaths += 1;

            }
        }

        if (perfectBreathCount >= 3)
        {
            perfectBreathComplete = true;
        }

        FOVincrement = Mathf.Clamp(FOVincrement, 0, 8f);
        baseIncrement = Mathf.Clamp(baseIncrement, 1f, 50f);

        //Set objects and components to change according to changing increment
        GetComponent<Camera>().fieldOfView = baseCameraPOV + (FOVincrement * 3);
        CircleFill.transform.localScale = new Vector3(.5f + FOVincrement * .3f, .5f + FOVincrement * .3f, CircleFill.transform.localScale.z);
        CircleFill2.transform.localScale = new Vector3(.5f + FOVincrement * .23f, .5f + FOVincrement * .23f, CircleFill.transform.localScale.z);
        CircleFill3.transform.localScale = new Vector3(.5f + FOVincrement * .16f, .5f + FOVincrement * .16f, CircleFill.transform.localScale.z);
        CircleFill4.transform.localScale = new Vector3(.5f + FOVincrement * .09f, .5f + FOVincrement * .09f, CircleFill.transform.localScale.z);


        //make breathCircle Appear
        colorAlpha += colorAlphaIncrease * Time.deltaTime;
        colorAlpha = Mathf.Clamp(colorAlpha, 0, .5f);
        CircleFill.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, colorAlpha);
        CircleFill2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, colorAlpha);
        CircleFill3.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, colorAlpha);
        CircleFill4.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, colorAlpha);
        CircleOutline.GetComponent<SpriteRenderer>().color = new Color(47f / 255f, 72f / 255, 188f / 255f, colorAlpha);

    }

    private void OnEnable()
    {
        eventManager.onTimerEnd += breathAppear;
    }
    private void OnDisable()
    {
        eventManager.onTimerEnd -= breathAppear;
    }

    void breathAppear()
    {
        colorAlphaIncrease = 1 / 15f;
        //audioSrc2.clip = introBrthCircSnd;
        //audioSrc2.Play();
    }
}
