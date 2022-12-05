using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarsClickable : MonoBehaviour, IPointerClickHandler
{
    private GameObject buyCarsUI;
    private bool closeBuyCarsUI;

    private int nextCar;
    private bool boughtCar;

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
        for (int i = 0; i < CarsUI.instance.allCars.Count; i++)
        {
            if (gameObject.name == CarsUI.instance.allCars[nextCar].name)
            {
                if (!closeBuyCarsUI)
                {
                    buyCarsUI = CarsUI.instance.allCars[nextCar].buyCarsPopup;
                    buyCarsUI.SetActive(true);
                    closeBuyCarsUI = true;
                }
                else
                {
                    buyCarsUI.SetActive(false);
                    closeBuyCarsUI = false;
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
