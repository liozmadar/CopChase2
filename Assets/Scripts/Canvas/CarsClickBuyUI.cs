using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarsClickBuyUI : MonoBehaviour, IPointerClickHandler
{
    private GameObject closeLockerUI;
    public bool buyTheCar;
    public GameObject carsBuyImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        //check if i can buy the car, and if i can , i decrease the totalScorePoints and buy the car
        for (int i = 0; i < CarsUI.instance.allCars.Count; i++)
        {
            //check if i already bought this car
            if (PlayerPrefs.GetInt(CarsUI.instance.allCars[i].id.ToString()) == 0)
            {
                if (CarsUI.instance.allCars[i].carBuyBoolImage == 1)
                {
                    if (ScoreSystem.instance.totalScorePoints >= CarsUI.instance.allCars[i].carCostNumber)
                    {
                        int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - CarsUI.instance.allCars[i].carCostNumber;
                        PlayerPrefs.SetInt(CarsUI.instance.allCars[i].id.ToString(), 1);

                        closeLockerUI = CarsUI.instance.allCars[i].carLockImage;
                        closeLockerUI.SetActive(false);
                        buyTheCar = true;

                        PlayerPrefs.SetInt("totalScorePoints", totalScorePointsAfterBuy);

                        carsBuyImage = GameObject.FindGameObjectWithTag("CarsBuyImage");
                        Destroy(carsBuyImage);

                        Debug.Log(CarsUI.instance.allCars[i].name);
                        Debug.Log(carsBuyImage);
                        CarsUI.instance.allCars[i].carBuyBoolImage = 0;
                    }
                }
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
