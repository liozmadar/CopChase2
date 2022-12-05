using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

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

    public List<CarDetailes> allCars;
    private int nextCar;
    private int nextPrefsName;

    public LayerMask layerUI;
    public float distance = 10000;

    // Start is called before the first frame update
    void Start()
    {
        deleteAllKeys = false;
    }

    // Update is called once per frame
    void Update()
    {
        RemoveOrKeepTheLockOnCarsUI();

        //Delete all keys , so its like reset the game totally
        if (deleteAllKeys)
        {
            DeleteAllKeys();
        }
        rayCast();
    }
    public void rayCast()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distance, layerUI))
            {
                Debug.Log("Hit anything");
                if (hit.collider.tag == "Check")
                {
                    Debug.Log("Check");
                }
            }
        }
    }
    void RemoveOrKeepTheLockOnCarsUI()
    {
        if (PlayerPrefs.GetInt(allCars[nextPrefsName].name) == 1)
        {
            allCars[nextPrefsName].carLockImage.SetActive(false);
        }
        nextPrefsName++;

        if (nextPrefsName >= allCars.Count)
        {
            nextPrefsName = 0;
        }


        /*  if (PlayerPrefs.GetInt("BoughtCar1") == 1)
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
          }*/
    }
    public void CarNumber0()
    {
        for (int i = 0; i < allCars.Count; i++)
        {
            if (PlayerPrefs.GetInt(allCars[nextCar].name) == 0)
            {
                if (ScoreSystem.instance.totalScorePoints >= allCars[nextCar].carCostNumber)
                {
                    int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - allCars[nextCar].carCostNumber;
                    PlayerPrefs.SetInt(allCars[nextCar].name, 1);
                    allCars[nextCar].carLockImage.SetActive(false);

                    PlayerPrefs.SetInt("totalScorePoints", totalScorePointsAfterBuy);
                }
            }
            nextCar++;
            if (nextCar >= allCars.Count)
            {
                nextCar = 0;
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
        PlayerPrefs.DeleteKey(allCars[nextPrefsName].name);
        PlayerPrefs.DeleteKey(allCars[nextPrefsName].name);
        PlayerPrefs.DeleteKey(allCars[nextPrefsName].name);
        PlayerPrefs.DeleteKey(allCars[nextPrefsName].name);
    }
}
