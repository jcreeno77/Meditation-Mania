using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sequenceController : MonoBehaviour
{
    AudioSource audSrc;
    [SerializeField] AudioClip VO1a;
    [SerializeField] AudioClip VO2a;
    [SerializeField] AudioClip VO2b;
    

    [SerializeField] GameObject videoPlayer;

    [SerializeField] GameObject selectBtn1;
    [SerializeField] GameObject selectBtn2;
    [SerializeField] GameObject selectBtn3;
    float selectBtnAlpha;

    float timer;
    bool pauseTime;
    bool emotionSelected;
    bool playVO2a;

    // Start is called before the first frame update
    private void OnEnable()
    {
        
        //Plays Robin voice, lowers music volume
        audSrc = GetComponent<AudioSource>();
        audSrc.clip = VO1a;
        audSrc.Play();
        videoPlayer.GetComponent<AudioSource>().volume -= .3f;

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

    }

    void EmotionSelected()
    {
        emotionSelected = true;
        pauseTime = false;
        selectBtnAlpha = 1f;
    }
}
