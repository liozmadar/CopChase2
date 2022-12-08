using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject endGameCard;
    public TextMeshProUGUI headerText;

    public TextMeshProUGUI timerScore;
    public TextMeshProUGUI copsDestroyed;
    public TextMeshProUGUI coneCollected;

    public TextMeshProUGUI bestScoreText;
    public int bestScoreCount;
    public TextMeshProUGUI mostCopsDestroyedText;
    public int mostCopsDestroyedCount;
    public TextMeshProUGUI mostConeCollectedText;
    public int mostConeCollectedCount;

    public TextMeshProUGUI coinsEarndFromConeCollected;

    public GameObject newScore;
    public bool newScoreBool;
    public GameObject newCops;
    public bool newCopsBool;
    public GameObject newCones;
    public bool newConesBool;

    //Home screen UI
    public GameObject buyCarsScreenUI;
    public GameObject homeScreenUI;
    public GameObject playerCarsChange;
    public GameObject endCardUI;
    private int endGameCardClickToPlayAgain;
    //

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //Get the prefs of 1 = close the homeUI , or 2 = keep the homeUI
        endGameCardClickToPlayAgain = PlayerPrefs.GetInt("PlayAgain");

        //Stop the car from moveing
        Time.timeScale = 0;

        //If 1 then you want to play again , after the game reset close the homeUI and and let the cars move
        if (endGameCardClickToPlayAgain == 1)
        {
            homeScreenUI.SetActive(false);
            PlayerPrefs.SetInt("PlayAgain", 0);
            Time.timeScale = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckTheBestScoreNumber();
        CheckIfNewScore();

        //DeleteAllKeys();
    }
    //All UI screens
    public void ClickToGoToBuyCarsUI()
    {
        homeScreenUI.SetActive(false);
        buyCarsScreenUI.SetActive(true);
        endCardUI.SetActive(false);
    }
    public void ClickToGoBackToHomeUI()
    {
        homeScreenUI.SetActive(true);
        buyCarsScreenUI.SetActive(false);
        endCardUI.SetActive(false);
        Time.timeScale = 0;
    }
    //Click to play the game from the first homeUI
    public void ClickToPlayGameFromHomeUI()
    {
        homeScreenUI.SetActive(false);
        playerCarsChange.SetActive(true);
        Time.timeScale = 1;

        for (int i = 0; i < CarsUI.instance.allCars.Count; i++)
        {
            if (PlayerPrefs.GetInt(CarsUI.instance.allCars[i].id.ToString()) == 1)
            {
                CarSelection.instance.availableCars.Add(CarSelection.instance.playerCarSelection[i]);
            }
        }
    }
    //Reset the game but close the first homeUI
    public void TryAgainButton()
    { 
        PlayerPrefs.SetInt("PlayAgain",1);
        SceneManager.LoadScene(0);
    }
    //Reset the game and keep the first homeUI
    public void GoToHomeUIAfterTheEndCard()
    {
        PlayerPrefs.SetInt("PlayAgain", 0);
        SceneManager.LoadScene(0);
    }
    //

    void CheckIfNewScore()
    {
        if (newScoreBool)
        {
            newScore.SetActive(true);
        }
        if (newConesBool)
        {
            newCones.SetActive(true);
        }
        if (newCopsBool)
        {
            newCops.SetActive(true);
        }
    }
    public void EndGameCardWin()
    {
        Invoke("DelayTheEndCardWin", 1);
    }
    void DelayTheEndCardWin()
    {
        endGameCard.SetActive(true);
        headerText.text = "You win!";
        timerScore.text = Timer.instance.timerText.ToString();
        copsDestroyed.text = GameManager.instance.copsDestroyedNumber.ToString();
        coneCollected.text = Cones.instance.coneCollectedCount.ToString();
        coinsEarndFromConeCollected.text =  "+" + Cones.instance.totalCoinsFromCones.ToString();
    }
    public void EndGameCardLose()
    {
        Invoke("DelayTheEndCardLose", 1);
    }
    void DelayTheEndCardLose()
    {
        endGameCard.SetActive(true);
        headerText.text = "Try again!";
        timerScore.text = Timer.instance.timerText.ToString();
        copsDestroyed.text = GameManager.instance.copsDestroyedNumber.ToString();
        coneCollected.text = Cones.instance.coneCollectedCount.ToString();
        coinsEarndFromConeCollected.text = "+" + Cones.instance.totalCoinsFromCones.ToString();
    }
    void MostConesCollectedCheck()
    {
        mostConeCollectedCount = Cones.instance.coneCollectedCount;
        PlayerPrefs.SetInt("Cones", mostConeCollectedCount);
    }
    void MostCopsDestroyed()
    {
        mostCopsDestroyedCount = GameManager.instance.copsDestroyedNumber;
        PlayerPrefs.SetInt("Cops", mostCopsDestroyedCount);
    }
    void BestScore()
    {
        bestScoreCount = Timer.instance.timerText;
        PlayerPrefs.SetInt("Score", bestScoreCount);
    }
    void CheckTheBestScoreNumber()
    {
        if (Cones.instance.coneCollectedCount > PlayerPrefs.GetInt("Cones"))
        {
            MostConesCollectedCheck();
            newConesBool = true;
        }
        else
        {
            mostConeCollectedText.text = PlayerPrefs.GetInt("Cones").ToString();
        }
        if (GameManager.instance.copsDestroyedNumber > PlayerPrefs.GetInt("Cops"))
        {
            MostCopsDestroyed();
            newCopsBool = true;
        }
        else
        {
            mostCopsDestroyedText.text = PlayerPrefs.GetInt("Cops").ToString();
        }
        if (Timer.instance.timerText > PlayerPrefs.GetInt("Score"))
        {
            BestScore();
            newScoreBool = true;
        }
        else
        {
            bestScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
    }
    void DeleteAllKeys()
    {
        PlayerPrefs.DeleteKey("Cones");
        PlayerPrefs.DeleteKey("Cops");
        PlayerPrefs.DeleteKey("Score");
    }
}
