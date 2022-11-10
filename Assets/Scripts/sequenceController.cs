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

    [SerializeField] AudioClip menuMusic;

    public bool breathActivate;
    public bool end;

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

    bool menumusicPlay;

    bool perfectBreathComplete;
    public bool perfectBreathBegin;

    [SerializeField] AudioClip forestSound;

    [SerializeField] GameObject videoPlayer;
    [SerializeField] GameObject gradingScreen;
    float gradeScreenAlpha;

    [SerializeField] GameObject selectBtn1;
    [SerializeField] GameObject selectBtn2;
    [SerializeField] GameObject selectBtn3;
    float selectBtnAlpha;

    float timer;
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
        timer = 0f;
        pauseTime = false;
        emotionSelected = false;
        selectBtn1.SetActive(true);
        selectBtn2.SetActive(true);
        selectBtn3.SetActive(true);
        selectBtnAlpha = 0f;
        selectBtn1.GetComponent<Image>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn2.GetComponent<Image>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn3.GetComponent<Image>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, selectBtnAlpha);
        selectBtn1.GetComponent<Button>().onClick.AddListener(EmotionSelected);
        selectBtn2.GetComponent<Button>().onClick.AddListener(EmotionSelected);
        selectBtn3.GetComponent<Button>().onClick.AddListener(EmotionSelected);
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
        selectBtn1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(.1f, .1f, .1f, selectBtnAlpha);
        selectBtn2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(.1f, .1f, .1f, selectBtnAlpha);
        selectBtn3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(.1f, .1f, .1f, selectBtnAlpha);


        if (timer > 7 && !emotionSelected)
        {
            pauseTime = true;
            selectBtnAlpha += Time.deltaTime;
        }
        if (emotionSelected && timer > 7f)
        {
            selectBtnAlpha -= Time.deltaTime;
        }

        if(timer > 8.2f && !playVO2a)
        {
            selectBtn1.SetActive(false);
            selectBtn2.SetActive(false);
            selectBtn3.SetActive(false);
            audSrc.PlayOneShot(VO2a);
            playVO2a = true;
        }

        if(timer > 13f && !playVO2b)
        {
            audSrc.PlayOneShot(VO2b);
            playVO2b = true;
        }

        if(timer > 23 && !playVO2c)
        {
            audSrc.PlayOneShot(VO2c);
            playVO2c = true;
        }

        if(timer > 40 && !playVO2d)
        {
            audSrc.PlayOneShot(VO2d);
            playVO2d = true;
        }

        if(timer > 49 && !playVO3a)
        {
            audSrc.PlayOneShot(VO3);
            playVO3a = true;

        }
        if(timer > 52)
        {
            //enables mainCam
            mainCam.GetComponent<breathScript>().enabled = true;
            if (!breathActivate)
            {
                breathActivate = true;
            }
        }

        if(timer > 84 && !playVO4a)
        {
            audSrc.PlayOneShot(VO4a);
            playVO4a = true;
        }
        if(timer > 106 && !playVO4b)
        {
            audSrc.PlayOneShot(VO4b);
            playVO4b = true;
            pauseTime = true;
            
        }
        if(timer > 106 && pauseTime && !perfectBreathComplete)
        {
            mainCam.GetComponent<breathScript>().perfectBreathBegin = true;
            if (mainCam.GetComponent<breathScript>().perfectBreathComplete)
            {
                perfectBreathComplete = true;
                pauseTime = false;
                mainCam.GetComponent<breathScript>().perfectBreathBegin = false;
                end = true;
            }
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
            gameObject.SetActive(false);
        }





    }

    void EmotionSelected()
    {
        emotionSelected = true;
        pauseTime = false;
        selectBtnAlpha = 1f;
    }
}
