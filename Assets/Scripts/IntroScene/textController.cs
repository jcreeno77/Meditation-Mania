using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class textController : MonoBehaviour
{
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] GameObject text4;
    [SerializeField] GameObject playBtn;
    [SerializeField] GameObject vidRenderer;
    [SerializeField] GameObject vidPlayer;
    [SerializeField] AudioSource audsrc;
    float timer;
    float color1;
    float color2;
    float color3;
    float alphaVideo;
    float alphaBtn;
    bool audioPlayed;

    Button BeginGame;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        color1 = 0f;
        color2 = 0f;
        color3 = 0f;
        alphaVideo = 0f;
        alphaBtn = 0f;
        audsrc = vidPlayer.GetComponent<AudioSource>();
        audioPlayed = false;

        BeginGame = playBtn.GetComponent<Button>();
        BeginGame.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > 2 && timer < 6)
        {
            color1 += Time.deltaTime;

        }
        else if (timer > 8 && timer < 12)
        {
            color2 += Time.deltaTime;
        }
        else if (timer > 14 && timer < 18)
        {
            color3 += Time.deltaTime;
        }
        else
        {
            color1 -= Time.deltaTime;
            color2 -= Time.deltaTime;
            color3 -= Time.deltaTime;
        }

        if (timer > 21)
        {
            text4.GetComponent<Text>().color = new Color(1, 1, 1, 1);
            if (!audioPlayed)
            {
                audsrc.Play();
                audioPlayed = true;
            }
        }

        

        if (timer > 23)
        {
            alphaVideo += Time.deltaTime;
            vidPlayer.GetComponent<VideoPlayer>().Play();
            alphaBtn += Time.deltaTime;
        }

        color1 = Mathf.Clamp(color1, 0, 1);
        color2 = Mathf.Clamp(color2, 0, 1);
        color3 = Mathf.Clamp(color3, 0, 1);
        text1.GetComponent<Text>().color = new Color(1, 1, 1, color1);
        text2.GetComponent<Text>().color = new Color(1, 1, 1, color2);
        text3.GetComponent<Text>().color = new Color(1, 1, 1, color3);
        vidRenderer.GetComponent<RawImage>().color = new Color(1, 1, 1, alphaVideo);
        playBtn.GetComponent<Image>().color = new Color(1, 1, 1, alphaBtn);
        playBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, alphaBtn);
    }


    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
