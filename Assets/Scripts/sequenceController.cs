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
    [SerializeField] AudioClip VO3a;
    [SerializeField] AudioClip VO3b;
    [SerializeField] AudioClip VO4a;
    [SerializeField] AudioClip VO4b;
    [SerializeField] AudioClip VO4c1;
    [SerializeField] AudioClip VO4c2;
    [SerializeField] AudioClip VO5;
    [SerializeField] AudioClip VO6;

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

    bool perfectBreathComplete;
    public bool perfectBreathBegin;

    [SerializeField] AudioClip forestSound;
    

    [SerializeField] GameObject videoPlayer;

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


        if (timer > 5 && !emotionSelected)
        {
            pauseTime = true;
            selectBtnAlpha += Time.deltaTime;
        }
        if (emotionSelected && timer > 5.2f)
        {
            selectBtnAlpha -= Time.deltaTime;
        }

        if(timer > 6.2f && !playVO2a)
        {
            selectBtn1.SetActive(false);
            selectBtn2.SetActive(false);
            selectBtn3.SetActive(false);
            audSrc.PlayOneShot(VO2a);
            playVO2a = true;
        }

        if(timer > 9.5f && !playVO2b)
        {
            audSrc.PlayOneShot(VO2b);
            playVO2b = true;
        }

        if(timer > 18 && !playVO2c)
        {
            audSrc.PlayOneShot(VO2c);
            playVO2c = true;
        }

        if(timer > 31 && !playVO2d)
        {
            audSrc.PlayOneShot(VO2d);
            playVO2d = true;
        }

        if(timer > 40 && !playVO3a)
        {
            audSrc.PlayOneShot(VO3a);
            playVO3a = true;

        }
        if(timer > 43)
        {
            mainCam.GetComponent<breathScript>().enabled = true;
            if (!breathActivate)
            {
                breathActivate = true;
            }
        }
        if (timer > 51 && !playVO3b)
        {
            
            audSrc.PlayOneShot(VO3b);
            playVO3b = true;
        }

        if(timer > 79 && !playVO4a)
        {
            audSrc.PlayOneShot(VO4a);
            playVO4a = true;
        }
        if(timer > 101 && !playVO4b)
        {
            audSrc.PlayOneShot(VO4b);
            playVO4b = true;
            pauseTime = true;
            mainCam.GetComponent<breathScript>().perfectBreathBegin = true;
        }
        if(timer > 101 && pauseTime && !perfectBreathComplete)
        {
            if (mainCam.GetComponent<breathScript>().perfectBreathComplete)
            {
                perfectBreathComplete = true;
                pauseTime = false;
                mainCam.GetComponent<breathScript>().perfectBreathBegin = false;
                end = true;
            }
        }





    }

    void EmotionSelected()
    {
        emotionSelected = true;
        pauseTime = false;
        selectBtnAlpha = 1f;
    }
}
