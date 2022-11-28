using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;

    public int totalScorePoints;
    //"totalScorePoints" is the playerPrefs

    public TextMeshProUGUI totalScorePointsText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        totalScorePoints = PlayerPrefs.GetInt("totalScorePoints");
        totalScorePointsText.text = "Total points:" + totalScorePoints.ToString();
    }
}
