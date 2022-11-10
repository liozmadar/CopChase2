using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject endGameCard;
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI timerScore;
    public TextMeshProUGUI copsDestroyed;
    public TextMeshProUGUI coneCollected;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TryAgainButton()
    {
        SceneManager.LoadScene(0);
    }
    public void EndGameCardWin()
    {
        endGameCard.SetActive(true);
        headerText.text = "You win!";
        timerScore.text = Timer.instance.timerText.ToString();
        copsDestroyed.text = GameManager.instance.copsDestroyedNumber.ToString();
        coneCollected.text = Cones.instance.coneCollectedCount.ToString();
    }
    public void EndGameCardLose()
    {
        endGameCard.SetActive(true);
        headerText.text = "Try again!";
        timerScore.text = Timer.instance.timerText.ToString();
        copsDestroyed.text = GameManager.instance.copsDestroyedNumber.ToString();
        coneCollected.text = Cones.instance.coneCollectedCount.ToString();
    }
}
