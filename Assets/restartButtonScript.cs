using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class restartButtonScript : MonoBehaviour
{
    public Button yourButton;
    public GameObject gradescreen;
    public GameObject sequenceController;
    public GameObject perforanceCollector;
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
        //reset timer
        //sequenceController.SetActive(true);
        //sequenceController.GetComponent<sequenceController>().timer = 129;
        //sequenceController.GetComponent<sequenceController>().end = false;


        //disable end screen
        Debug.Log("Restarted");
        gradescreen.SetActive(false);

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
        
    }
}
