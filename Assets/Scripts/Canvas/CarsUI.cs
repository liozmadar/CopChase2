using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsUI : MonoBehaviour
{
    public GameObject[] allLockedCars;

    public int carCostNumber0;
    public int carCostNumber1;
    public int carCostNumber2;
    public int carCostNumber3;
    public int carCostNumber4;
    public int carCostNumber5;

    public bool deleteAllKeys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("BoughtCar0") == 1)
        {
            allLockedCars[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("BoughtCar1") == 1)
        {
            allLockedCars[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("BoughtCar2") == 1)
        {
            allLockedCars[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("BoughtCar3") == 1)
        {
            allLockedCars[3].SetActive(false);
        }

        //Delete all keys , so its like reset the game totally
        if (deleteAllKeys)
        {
            DeleteAllKeys();
        }
    }
    public void CarNumber0()
    {
        if (PlayerPrefs.GetInt("BoughtCar0") == 0)
        {
            if (ScoreSystem.instance.totalScorePoints >= carCostNumber0)
            {
                int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - carCostNumber0;
                PlayerPrefs.SetInt("BoughtCar0", 1);
                allLockedCars[0].SetActive(false);

                PlayerPrefs.SetInt("totalScorePoints", totalScorePointsAfterBuy);
            }
        }
    }
    public void CarNumber1()
    {
        if (PlayerPrefs.GetInt("BoughtCar1") == 0)
        {
            if (ScoreSystem.instance.totalScorePoints >= carCostNumber1)
            {
                int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - carCostNumber1;
                PlayerPrefs.SetInt("BoughtCar1", 1);
                allLockedCars[1].SetActive(false);

                PlayerPrefs.SetInt("totalScorePoints", totalScorePointsAfterBuy);
            }
        }
    }
    public void CarNumber2()
    {
        if (PlayerPrefs.GetInt("BoughtCar2") == 0)
        {
            if (ScoreSystem.instance.totalScorePoints >= carCostNumber2)
            {
                int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - carCostNumber2;
                PlayerPrefs.SetInt("BoughtCar2", 1);
                allLockedCars[2].SetActive(false);

                PlayerPrefs.SetInt("totalScorePoints", totalScorePointsAfterBuy);
            }
        }
    }
    public void CarNumber3()
    {
        if (PlayerPrefs.GetInt("BoughtCar3") == 0)
        {
            if (ScoreSystem.instance.totalScorePoints >= carCostNumber3)
            {
                int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - carCostNumber3;
                PlayerPrefs.SetInt("BoughtCar3", 1);
                allLockedCars[3].SetActive(false);

                PlayerPrefs.SetInt("totalScorePoints", totalScorePointsAfterBuy);
            }
        }
    }
    void DeleteAllKeys()
    {
        PlayerPrefs.DeleteKey("BoughtCar0");
        PlayerPrefs.DeleteKey("BoughtCar1");
        PlayerPrefs.DeleteKey("BoughtCar2");
        PlayerPrefs.DeleteKey("BoughtCar3");
    }
}
