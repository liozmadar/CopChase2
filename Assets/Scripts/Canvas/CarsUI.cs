using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class CarsUI : MonoBehaviour
{
    public static CarsUI instance;

    public List<CarDetailes> allCars;
    private int nextPrefsName;

    public bool deleteAllKeys;
    public int deleteAllKeysNumbers;

   // public GameObject resetGameImage;
   // private bool resetGameOpenCloseImage;

    public int addTotalPoints;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        deleteAllKeys = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Delete all keys , so its like reset the game totally
        if (deleteAllKeys)
        {
            DeleteAllKeys();
        }
        else if (!deleteAllKeys)
        {
            RemoveOrKeepTheLockOnCarsUI();
        }
    }
    public void AddTotalPoints()
    {
        int TotalPointsAfterAd = ScoreSystem.instance.totalScorePoints + addTotalPoints;
        PlayerPrefs.SetInt("totalScorePoints", TotalPointsAfterAd);
    }
    void RemoveOrKeepTheLockOnCarsUI()
    {
        if (PlayerPrefs.GetInt(allCars[nextPrefsName].id.ToString()) == 1)
        {
            allCars[nextPrefsName].carLockImage.SetActive(false);
        }
        nextPrefsName++;

        if (nextPrefsName >= allCars.Count)
        {
            nextPrefsName = 0;
        }
    }
    public void DeleteAllKeys()
    {
        deleteAllKeys = true;
        for (int i = 0; i < allCars.Count; i++)
        {
            PlayerPrefs.DeleteKey(allCars[deleteAllKeysNumbers].id.ToString());
            DeleteAllKeys();
            deleteAllKeysNumbers++;
            if (deleteAllKeysNumbers >= allCars.Count)
            {
                deleteAllKeysNumbers = 0;
            }
        }
        SceneManager.LoadScene(0);
    }
}
