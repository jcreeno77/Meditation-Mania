using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sequenceController : MonoBehaviour
{
    [SerializeField] GameObject mainCam;

    AudioSource audSrc;

    [SerializeField] AudioClip VO1a;
    [SerializeField] AudioClip VO2a;
    [SerializeField] AudioClip VO2b;
    [SerializeField] AudioClip VO2c;
    [SerializeField] AudioClip VO2d;
    [SerializeField] AudioClip VO3;
    //[SerializeField] AudioClip VO3b;
    [SerializeField] AudioClip VO4a;
    [SerializeField] AudioClip VO4b;
    [SerializeField] AudioClip VO4c1;
    [SerializeField] AudioClip VO4c2;
    [SerializeField] AudioClip VO5;
    [SerializeField] AudioClip VO6;
    [SerializeField] AudioClip VO7a;
    [SerializeField] AudioClip VO7b;
    [SerializeField] AudioClip VO8a;
    [SerializeField] AudioClip VO8b;
    [SerializeField] AudioClip VO8c;
    [SerializeField] AudioClip VO11;

    [SerializeField] AudioClip menuMusic;

    public bool breathActivate;
    public bool end;
    public bool thoughtSequenceComplete;
    public bool blastSequenceComplete;
    bool blastSequenceBegin;

    bool playVO2a;
    bool playVO2b;
    bool playVO2c;
    bool playVO2d;
    bool playVO3a;
    bool playVO3b;
    bool playVO4a;
    bool playVO4b;
    bool playVO4c1;
    bool playVO4c2;
    bool playVO5;
    bool playVO6;
    //bool playVO7a;
    //bool playVO7b;
    bool playVO8a;
    bool playVO8b;
    bool playVO8c;
    bool playVO11;

    bool menumusicPlay;

    bool perfectBreathComplete;
    public bool perfectBreathBegin;
    bool breathInOut = false;

    [SerializeField] AudioClip forestSound;

    [SerializeField] GameObject videoPlayer;
    [SerializeField] GameObject gradingScreen;
    [SerializeField] GameObject perfectBreaths;
    [SerializeField] GameObject goodBreaths;
    [SerializeField] GameObject missedBreaths;
    [SerializeField] GameObject badBreath;
    float gradeScreenAlpha;

    [SerializeField] GameObject selectBtn1;
    [SerializeField] GameObject selectBtn2;
    [SerializeField] GameObject selectBtn3;
    [SerializeField] GameObject thoughtSpawner;
    [SerializeField] GameObject thoughtObject;
    float selectBtnAlpha;

    public float timer;
    float thoughtSequencetimer = 0;
    float blastSequencetimer = 0;
    public bool thoughtSequenceClicked = false;
    int thoughtSequenceTimesClicked = 0;
    bool pauseTime;
    bool emotionSelected;


    // Start is called before the first frame update
    private void OnEnable()
    {
        breathActivate = false;
        perfectBreathComplete = false;
        //Plays Robin voice, lowers music volume
        audSrc = GetComponent<AudioSource>();
        audSrc.clip = VO1a;
        audSrc.Play();
        videoPlayer.GetComponent<AudioSource>().volume = Mathf.Lerp(videoPlayer.GetComponent<AudioSource>().volume, 0.2f, .01f);

        //START SETTINGS
        //selBtn settings
        timer = 65f;
        pauseTime = false;
        emotionSelected = false;
        breathInOut = false;

        selectBtnAlpha = 1f;
        selectBtn1.GetComponent<Image>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn2.GetComponent<Image>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn3.GetComponent<Image>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, selectBtnAlpha);

        playVO2a = false;
        playVO2b = false;
        playVO2c = false;
        perfectBreathBegin = false;
        mainCam.GetComponent<breathScript>().enabled = false;
        end = false;
        gradeScreenAlpha = 0f;
        menumusicPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseTime) timer += Time.deltaTime;
        selectBtn1.GetComponent<Image>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn2.GetComponent<Image>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn3.GetComponent<Image>().color = new Color(1, 1, 1, selectBtnAlpha);

        if (timer > 5 && !emotionSelected)
        {
            pauseTime = true;
            selectBtnAlpha += Time.deltaTime;
            selectBtn1.SetActive(true);
            selectBtn2.SetActive(true);
            selectBtn3.SetActive(true);
            selectBtn1.GetComponent<Button>().onClick.AddListener(EmotionSelected);
            selectBtn2.GetComponent<Button>().onClick.AddListener(EmotionSelected);
            selectBtn3.GetComponent<Button>().onClick.AddListener(EmotionSelected);
        }
        if (emotionSelected && timer > 6f)
        {
            selectBtnAlpha -= Time.deltaTime;
        }

        if (timer > 7f && !playVO2a)
        {
            selectBtn1.SetActive(false);
            selectBtn2.SetActive(false);
            selectBtn3.SetActive(false);
            audSrc.PlayOneShot(VO2a);
            playVO2a = true;
        }

        if (timer > 11f && !playVO2b)
        {
            audSrc.PlayOneShot(VO2b);
            playVO2b = true;
        }

        if (timer > 16 && !playVO2c)
        {
            audSrc.PlayOneShot(VO2c);
            playVO2c = true;
        }

        if (timer > 32 && !playVO2d)
        {
            audSrc.PlayOneShot(VO2d);
            playVO2d = true;
        }

        if (timer > 43 && !playVO3a)
        {
            audSrc.PlayOneShot(VO3);
            playVO3a = true;

        }
        //BreathIn BreathOut
        if (timer > 75 && !playVO4a)
        {
            audSrc.PlayOneShot(VO4a);
            playVO4a = true;
            //pauseTime = true;
        }

        if (timer > 97)
        {
            //enables mainCam
            mainCam.GetComponent<breathScript>().enabled = true;
            if (!breathActivate)
            {
                breathActivate = true;
            }
        }

        if (timer > 98 && !playVO4b)
        {
            audSrc.PlayOneShot(VO4b);
            playVO4b = true;
            pauseTime = true;

        }
        if (timer > 98 && pauseTime && !perfectBreathComplete)
        {
            mainCam.GetComponent<breathScript>().perfectBreathBegin = true;
            if (mainCam.GetComponent<breathScript>().perfectBreathComplete)
            {
                perfectBreathComplete = true;
                pauseTime = false;
                mainCam.GetComponent<breathScript>().perfectBreathBegin = false;
                //end = true;
            }
        }

        if (timer > 99.5f && !playVO5)
        {
            audSrc.PlayOneShot(VO5);
            playVO5 = true;

        }
        
        if (timer > 110 && !playVO6)
        {
            audSrc.PlayOneShot(VO6);
            playVO6 = true;
            pauseTime = true;
            GameObject tempThought = Instantiate(thoughtObject);
            tempThought.transform.position = new Vector3(19f, 3f, 0f);
            tempThought.GetComponent<thoughtMovement>().thoughtInSequence = true;
        }
        //THOUGHT SEQUENCE CODE
        if (timer > 110 && pauseTime && !thoughtSequenceComplete)
        {
            thoughtSequencetimer += Time.deltaTime;

            if(thoughtSequencetimer > 8f)
            {
                thoughtSequencetimer = 0f;
                audSrc.PlayOneShot(VO7b);
            }
            if (thoughtSequenceClicked)
            {
                thoughtSequenceClicked = false;
                thoughtSequencetimer = 0f;
                
                if(thoughtSequenceTimesClicked == 3)
                {
                    thoughtSequenceComplete = true;
                    pauseTime = false;
                }
                else
                {
                    //audSrc.PlayOneShot(VO7a);
                    GameObject tempThought = Instantiate(thoughtObject);
                    tempThought.transform.position = new Vector3(19f, Random.Range(-2f, 2f), 0f);
                    tempThought.GetComponent<thoughtMovement>().thoughtInSequence = true;
                }
                thoughtSequenceTimesClicked++;

            }
        }

        if(timer > 112 && !playVO8a)
        {
            playVO8a = true;
            audSrc.PlayOneShot(VO8a);
            
        }

        if(timer > 128 && !playVO8b)
        {
            playVO8b = true;
            audSrc.PlayOneShot(VO8b);
            pauseTime = true;
            mainCam.GetComponent<breathScript>().blastBegin = true;
            blastSequenceBegin = true;
        }

        if(timer > 128 && pauseTime && blastSequenceBegin)
        {
            blastSequencetimer += Time.deltaTime;
            if(blastSequencetimer > 13)
            {
                audSrc.PlayOneShot(VO8b);
                blastSequencetimer = 0;
            }
            if (mainCam.GetComponent<breathScript>().blastSequenceComplete)
            {
                blastSequenceBegin = false;
                pauseTime = false;
            }
        }

        if(timer>129 && !playVO11)
        {
            audSrc.PlayOneShot(VO11);
            playVO11 = true;
        }

        if (timer > 135)
        {
            //audSrc.volume = 1;
            thoughtSpawner.SetActive(true);
            gameObject.SetActive(false);
            mainCam.GetComponent<breathScript>().gameStart = true;
        }


        if (end)
        {
            Debug.Log("Going");
            mainCam.GetComponent<breathScript>().colorAlpha -= Time.deltaTime * 2;
            audSrc.volume -= Time.deltaTime;
        }

        if (timer > 108 && end)
        {
            gradingScreen.SetActive(true);
            gradeScreenAlpha += Time.deltaTime;
            gradingScreen.GetComponent<Image>().color = new Color(1, 1, 1, gradeScreenAlpha);
            perfectBreaths.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            goodBreaths.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            missedBreaths.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            badBreath.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);

            if (!menumusicPlay)
            {
                videoPlayer.GetComponent<AudioSource>().clip = menuMusic;
                videoPlayer.GetComponent<AudioSource>().Play();
                menumusicPlay = true;
            }
        }
        if (timer > 111 && end)
        {
            mainCam.GetComponent<breathScript>().enabled = false;
            //gameObject.SetActive(false);
        }





    }

    void EmotionSelected()
    {
        emotionSelected = true;
        pauseTime = false;
        selectBtnAlpha = 1f;
    }
}
