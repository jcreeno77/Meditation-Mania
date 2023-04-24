using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class performanceCollector : MonoBehaviour
{
    [SerializeField] GameObject mainCam;
    public int perfectBreaths;
    public int goodBreaths;
    public int badBreaths;
    public int missedBreaths;

    public int totalCombos;
    public int maxCombos;
    public int worstCombos;

    public int notedThoughts;
    public int releasedThoughts;
    public int badThoughts;

    public int breathPoints;
    public int thoughtPoints;
    public int comboPoints;

    public int totalScore;

    public int thoughtsInside;

    [SerializeField] GameObject perfBreath;
    [SerializeField] GameObject goodBreath;
    [SerializeField] GameObject badBreath;
    [SerializeField] GameObject missedBreath;
    [SerializeField] GameObject notedThoughtsObj;
    [SerializeField] GameObject releasedThoughtsObj;
    [SerializeField] GameObject totalScoreObj;
    [SerializeField] GameObject timeObj;

    [SerializeField] GameObject circleFill;
    [SerializeField] GameObject circleFill1;
    [SerializeField] GameObject circleFill2;
    [SerializeField] GameObject circleFill3;
    [SerializeField] GameObject circleOutline;

    public int currentCombo;
    public int currentTotalScore;
    [SerializeField] GameObject currentComboText;
    [SerializeField] GameObject currentComboTitle;
    [SerializeField] GameObject currentTotalScoreText;
    [SerializeField] GameObject currentTotalScoreTitle;
    [SerializeField] GameObject thoughtspawner;
    [SerializeField] GameObject gradingScreen;
    [SerializeField] GameObject videoPlayer;
    [SerializeField] AudioClip menuMusic;

    float gradeScreenAlpha;
    bool menumusicPlay;

    public bool endGame;


    // Start is called before the first frame update
    private void OnEnable()
    {
        endGame = false;
        menumusicPlay = false;
        gradeScreenAlpha = 0;

        perfectBreaths = 0;
        goodBreaths = 0;
        badBreaths = 0;
        missedBreaths = 0;

        totalCombos = 0;
        maxCombos = 0;
        worstCombos = 0;

        notedThoughts = 0;
        releasedThoughts = 0;
        badThoughts = 0;

        breathPoints = 0;
        thoughtPoints = 0;
        comboPoints = 0;

        totalScore = 0;
        currentCombo = 1;
        currentTotalScore = 0;

        thoughtsInside = 0;


    }
    private void Update()
    {
        perfBreath.GetComponent<TextMeshProUGUI>().text = perfectBreaths.ToString();
        goodBreath.GetComponent<TextMeshProUGUI>().text = goodBreaths.ToString();
        missedBreath.GetComponent<TextMeshProUGUI>().text = missedBreaths.ToString();
        notedThoughtsObj.GetComponent<TextMeshProUGUI>().text = notedThoughts.ToString();
        releasedThoughtsObj.GetComponent<TextMeshProUGUI>().text = releasedThoughts.ToString();
        totalScoreObj.GetComponent<TextMeshProUGUI>().text = totalScore.ToString();
        timeObj.GetComponent<TextMeshProUGUI>().text = ((int)Time.time).ToString();
        //combo values
        currentComboText.GetComponent<TextMeshProUGUI>().text = currentCombo.ToString()+"x";
        currentTotalScoreText.GetComponent<TextMeshProUGUI>().text = totalScore.ToString();

        if (mainCam.GetComponent<breathScript>().gameStart)
        {
            currentComboText.SetActive(true);
            currentComboTitle.SetActive(true); 
            currentTotalScoreText.SetActive(true);
            currentTotalScoreTitle.SetActive(true);
        }
        currentCombo = Mathf.Clamp(currentCombo, 1, 8);


        
        if (thoughtsInside > 5)
        {
            //End game
            thoughtspawner.SetActive(false);
            endGame = true;

            mainCam.GetComponent<breathScript>().colorAlpha -= Time.deltaTime * 2;

            gradingScreen.SetActive(true);
            gradeScreenAlpha += Time.deltaTime;
            gradingScreen.GetComponent<Image>().color = new Color(1, 1, 1, gradeScreenAlpha);
            perfBreath.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            goodBreath.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            missedBreath.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            badBreath.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            notedThoughtsObj.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            releasedThoughtsObj.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            totalScoreObj.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);
            timeObj.GetComponent<TextMeshProUGUI>().color = new Color(29f / 255f, 104f / 255f, 168f / 255f, gradeScreenAlpha);

            circleFill.SetActive(false);
            circleFill1.SetActive(false);
            circleFill2.SetActive(false);
            circleFill3.SetActive(false);
            circleOutline.SetActive(false);
            
            //disable breathscript
            mainCam.GetComponent<breathScript>().enabled = false;

            if (!menumusicPlay)
            {
                videoPlayer.GetComponent<AudioSource>().clip = menuMusic;
                videoPlayer.GetComponent<AudioSource>().Play();
                menumusicPlay = true;
            }
        }

    }

}
