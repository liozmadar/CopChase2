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
        //check if i can buy the car, and if i can , i decrease the totalScorePoints and buy the car
        for (int i = 0; i < CarsUI.instance.allCars.Count; i++)
        {
            //check if i already bought this car
            if (PlayerPrefs.GetInt(CarsUI.instance.allCars[nextCar].id.ToString()) == 0)
            {

                if (gameObject.name == CarsUI.instance.allCars[nextCar].name)
                {
                    //check if the totalCoins is more than the car cost
                    if (ScoreSystem.instance.totalScorePoints >= CarsUI.instance.allCars[nextCar].carCostNumber)
                    {
                        int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - CarsUI.instance.allCars[nextCar].carCostNumber;
                        PlayerPrefs.SetInt(CarsUI.instance.allCars[nextCar].id.ToString(), 1);

                        closeLockerUI = CarsUI.instance.allCars[nextCar].carLockImage;
                        closeLockerUI.SetActive(false);
                        buyTheCar = true;

                        CarsUI.instance.allCars[nextCar].name = "UnNamedCar";
                        CarsUI.instance.allCars[nextCar].buyCarsPopup.gameObject.SetActive(false);

                        PlayerPrefs.SetInt("totalScorePoints", totalScorePointsAfterBuy);
                    }
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
