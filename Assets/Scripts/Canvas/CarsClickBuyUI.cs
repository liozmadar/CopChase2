using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarsClickBuyUI : MonoBehaviour, IPointerClickHandler
{
    private GameObject closeLockerUI;
    public bool buyTheCar;
    public GameObject carsBuyImage;
    public GameObject notEnoughCoinsImage;
    public GameObject notEnoughCoinsImagePrefab;
    private bool notEnoughCoinsImagePrefabBool;
    private float notEnoughCoinsImagePrefabTimer = 500;


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
                    carsBuyImage = GameObject.FindGameObjectWithTag("CarsBuyImage");
                    if (ScoreSystem.instance.totalScorePoints >= CarsUI.instance.allCars[i].carCostNumber)
                    {
                        int totalScorePointsAfterBuy = ScoreSystem.instance.totalScorePoints - CarsUI.instance.allCars[i].carCostNumber;
                        PlayerPrefs.SetInt(CarsUI.instance.allCars[i].id.ToString(), 1);

                        closeLockerUI = CarsUI.instance.allCars[i].carLockImage;
                        closeLockerUI.SetActive(false);
                        buyTheCar = true;

                        PlayerPrefs.SetInt("totalScorePoints", totalScorePointsAfterBuy);


                        Destroy(carsBuyImage);

                        Debug.Log(CarsUI.instance.allCars[i].name);
                        Debug.Log(carsBuyImage);
                        CarsUI.instance.allCars[i].carBuyBoolImage = 0;
                    }
                    else
                    {
                        Vector3 offSet = new Vector3(0, 0, 0);
                        GameObject carBuyImagePrefab = GameObject.FindGameObjectWithTag("CarsBuyImage");
                        notEnoughCoinsImagePrefab = Instantiate(notEnoughCoinsImage, offSet, Quaternion.identity);
                        notEnoughCoinsImagePrefab.transform.SetParent(carBuyImagePrefab.transform, false);
                        Debug.Log(notEnoughCoinsImagePrefab);

                        notEnoughCoinsImagePrefabBool = true;
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
        DestroyNotEnoughCoinsImagePrefab();
    }
    void DestroyNotEnoughCoinsImagePrefab()
    {
        if (notEnoughCoinsImagePrefabBool)
        {
            notEnoughCoinsImagePrefabTimer --;
            if (notEnoughCoinsImagePrefabTimer <= 0)
            {
                Destroy(notEnoughCoinsImagePrefab);
                notEnoughCoinsImagePrefabTimer = 500;
                notEnoughCoinsImagePrefabBool = false;
            }
        }
    }
}
