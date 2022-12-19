using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarsClickable : MonoBehaviour, IPointerClickHandler
{
    private GameObject buyCarsUI;
    private bool closeBuyCarsUI;
    private GameObject closeCarsUI;


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
       // Here i open/close the - buy cars popup window 
        for (int i = 0; i < CarsUI.instance.allCars.Count; i++)
        {
            if (gameObject.name == CarsUI.instance.allCars[i].name)
            {
                if (!closeBuyCarsUI)
                {
                    buyCarsUI = CarsUI.instance.allCars[i].buyCarsPopup;
                    buyCarsUI.SetActive(true);
                    closeBuyCarsUI = true;
                }
                else
                {
                    buyCarsUI.SetActive(false);
                    closeBuyCarsUI = false;
                }
            }
        }
    }
}
