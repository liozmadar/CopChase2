using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarsClickable : MonoBehaviour, IPointerClickHandler
{
    private GameObject buyCarsUI;
    private bool closeBuyCarsUI;
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
    }
}
