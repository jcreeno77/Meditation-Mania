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
    [SerializeField] GameObject sequenceController;
    [SerializeField] AudioSource audsrc;
    [SerializeField] GameObject stillGameObject;

    float timer;
    float color1;
    float color2;
    float color3;
    float color4;
    float alphaVideo;
    float alphaBtn;
    bool audioPlayed;
    bool startGame;
    float transitionTimer;

    Button BeginGame;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        transitionTimer = 0f;
        color1 = 0f;
        color2 = 0f;
        color3 = 0f;
        color4 = 1f;
        alphaVideo = 0f;
        alphaBtn = 0f;
        audsrc = vidPlayer.GetComponent<AudioSource>();
        audioPlayed = false;
        startGame = false;

        BeginGame = playBtn.GetComponent<Button>();
        BeginGame.onClick.AddListener(StartGame);
        playBtn.SetActive(false);

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

        if (timer > 19 && !startGame)
        {
            stillGameObject.SetActive(true);
            if (!audioPlayed)
            {
                audsrc.Play();
                audioPlayed = true;
            }

            playBtn.SetActive(false);
        }

        

        if (timer > 22)
        {
            alphaVideo += Time.deltaTime/2f;
            vidPlayer.GetComponent<VideoPlayer>().Play();
            playBtn.SetActive(true);
        }

        if (startGame){
            //fade out 'still' and start Robin Audio
            color4 -= Time.deltaTime;
            transitionTimer += Time.deltaTime;
            if(transitionTimer > 3)
            {
                //Transitions to next script, begins game
                sequenceController.SetActive(true);
                gameObject.SetActive(false);
            }
            
        }

        color1 = Mathf.Clamp(color1, 0, 1);
        color2 = Mathf.Clamp(color2, 0, 1);
        color3 = Mathf.Clamp(color3, 0, 1);
        text1.GetComponent<Text>().color = new Color(1, 1, 1, color1);
        text2.GetComponent<Text>().color = new Color(1, 1, 1, color2);
        text3.GetComponent<Text>().color = new Color(1, 1, 1, color3);
        text4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, color4);
        vidRenderer.GetComponent<RawImage>().color = new Color(1, 1, 1, alphaVideo);
        playBtn.GetComponent<Image>().color = new Color(1, 1, 1, alphaBtn);

    }


    void StartGame()
    {
        playBtn.SetActive(false);
        startGame = true;
    }
}
