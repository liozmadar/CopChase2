using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarsClickBuyUI : MonoBehaviour, IPointerClickHandler
{
    private GameObject closeLockerUI;
    private int nextCar;
    public bool buyTheCar;

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < CarsUI.instance.allCars.Count; i++)
        {
            nextCar++;
        }
        if (nextCar >= CarsUI.instance.allCars.Count)
        {
            nextCar = 0;
        }

        for (int i = 0; i < CarsUI.instance.allCars.Count; i++)
        {
            if (PlayerPrefs.GetInt(CarsUI.instance.allCars[nextCar].name) == 0)
            {
                if (gameObject.name == CarsUI.instance.allCars[nextCar].name)
                {
                    int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - CarsUI.instance.allCars[nextCar].carCostNumber;
                    PlayerPrefs.SetInt(CarsUI.instance.allCars[nextCar].name, 1);

                    closeLockerUI = CarsUI.instance.allCars[nextCar].carLockImage;
                    closeLockerUI.SetActive(false);
                    buyTheCar = true;
                    CarsUI.instance.allCars[nextCar].name = "UnNamedCar";

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
