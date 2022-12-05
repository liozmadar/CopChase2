using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CarsUI : MonoBehaviour
{
    public static CarsUI instance;

    public List<CarDetailes> allCars;
    private int nextPrefsName;

    public bool deleteAllKeys;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
    }
    public void DeleteAllKeys()
    {
        PlayerPrefs.DeleteKey(allCars[nextPrefsName].name);
        PlayerPrefs.DeleteKey(allCars[nextPrefsName].name);
        PlayerPrefs.DeleteKey(allCars[nextPrefsName].name);
        PlayerPrefs.DeleteKey(allCars[nextPrefsName].name);
    }
}
