using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarsClickable : MonoBehaviour, IPointerClickHandler
{
    private GameObject buyCarsUI;
    private bool closeBuyCarsUI;

    private GameObject closeLockerUI;
    private int nextCar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!closeBuyCarsUI)
        {
            buyCarsUI = transform.GetChild(2).gameObject;
            buyCarsUI.SetActive(true);
            closeBuyCarsUI = true;
        }
        else
        {
            buyCarsUI.SetActive(false);
            closeBuyCarsUI = false;
        }

        for (int i = 0; i < CarsUI.instance.allCars.Count; i++)
        {
            if (PlayerPrefs.GetInt(CarsUI.instance.allCars[nextCar].name) == 0)
            {
                if (gameObject.name == CarsUI.instance.allCars[nextCar].name)
                {
                    int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - CarsUI.instance.allCars[nextCar].carCostNumber;
                    PlayerPrefs.SetInt(CarsUI.instance.allCars[nextCar].name, 1);

                    closeLockerUI = transform.GetChild(1).gameObject;
                    closeLockerUI.SetActive(false);

                    PlayerPrefs.SetInt("totalScorePoints", totalScorePointsAfterBuy);
                }
            }
            nextCar++;
            if (nextCar >= CarsUI.instance.allCars.Count)
            {
                nextCar = 0;
            }
        }
        
    }
}
