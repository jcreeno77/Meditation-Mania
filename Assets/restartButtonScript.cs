using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class restartButtonScript : MonoBehaviour
{
    public Button yourButton;
    public GameObject gradescreen;
    public GameObject sequenceController;
    public GameObject perforanceCollector;
    public GameObject mainCam;
    public GameObject perfCollector;
    public GameObject thoughtspawner;

    public GameObject circleFill;
    public GameObject circleFill1;
    public GameObject circleFill2;
    public GameObject circleFill3;
    public GameObject circleOutline;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
    }
    // Update is called once per frame
    void TaskOnClick()
    {
        //activate sequence controller
        //enable and change performance collector stuff
        perfCollector.GetComponent<performanceCollector>().thoughtsInside = 0;
        perfCollector.GetComponent<performanceCollector>().endGame = false;


        //reset timer
        sequenceController.SetActive(true);
        sequenceController.GetComponent<sequenceController>().timer = 129;
        sequenceController.GetComponent<sequenceController>().end = false;
        mainCam.GetComponent<breathScript>().enabled = true;


        //thought spawner details
        thoughtspawner.SetActive(true);
        thoughtspawner.GetComponent<ThoughtSpawner>().timeLimit = 5f;
        

        //reset metrics
        perforanceCollector.GetComponent<performanceCollector>().perfectBreaths = 0;
        perforanceCollector.GetComponent<performanceCollector>().goodBreaths = 0;
        perforanceCollector.GetComponent<performanceCollector>().badBreaths = 0;
        perforanceCollector.GetComponent<performanceCollector>().missedBreaths = 0;
        perforanceCollector.GetComponent<performanceCollector>().notedThoughts = 1;
        perforanceCollector.GetComponent<performanceCollector>().releasedThoughts = 0;
        perforanceCollector.GetComponent<performanceCollector>().totalScore = 0;
        perforanceCollector.GetComponent<performanceCollector>().currentCombo = 0;
        perforanceCollector.GetComponent<performanceCollector>().currentTotalScore = 0;

        circleFill.SetActive(true);
        circleFill1.SetActive(true);
        circleFill2.SetActive(true);
        circleFill3.SetActive(true);
        circleOutline.SetActive(true);


        //disable end screen
        Debug.Log("Restarted");
        gradescreen.SetActive(false);

    }
}
