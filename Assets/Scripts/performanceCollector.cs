using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField] GameObject perfBreath;
    [SerializeField] GameObject goodBreath;
    [SerializeField] GameObject badBreath;
    [SerializeField] GameObject missedBreath;

    // Start is called before the first frame update
    private void OnEnable()
    {
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



    }
    private void Update()
    {
        perfBreath.GetComponent<TextMeshProUGUI>().text = perfectBreaths.ToString();
        goodBreath.GetComponent<TextMeshProUGUI>().text = goodBreaths.ToString();
        missedBreath.GetComponent<TextMeshProUGUI>().text = missedBreaths.ToString();
    }

}
