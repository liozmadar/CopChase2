using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarsClickable : MonoBehaviour, IPointerClickHandler
{
    private GameObject buyCarsUI;
    public bool isOpen;
    private GameObject closeCarsUI;

    public GameObject buyCarsUIImage;
    private GameObject canvas;
    private Vector3 offSet = new Vector3(0, -300, 0);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void HideToolTip()
    {
        if (canvas != null && isOpen)
        {
            Destroy(canvas);
            isOpen = false;
        }
    }
    private void ShowToolTip(int i)
    {
        Debug.Log("Show");
        canvas = Instantiate(buyCarsUIImage, transform.position + offSet, Quaternion.identity);
        canvas.transform.SetParent(CarsUI.instance.carsImages[i], false);
        ShowCarCostText.instance.carsCostText.text = CarsUI.instance.allCars[i].carCostNumber.ToString();
        isOpen = true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < CarsUI.instance.allCars.Count; i++)
        {
            if (gameObject.name == CarsUI.instance.allCars[i].name)
            {
                if (isOpen) HideToolTip();
                else ShowToolTip(i);
            }
            else
            {
                CarsClickable carsClickable = CarsUI.instance.carsImages[i].gameObject.GetComponent<CarsClickable>();
                carsClickable.HideToolTip();
            }
        }
    }
}
