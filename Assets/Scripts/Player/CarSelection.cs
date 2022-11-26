using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    public static CarSelection instance;
    public GameObject[] playerCarSelection;
    public GameObject firstStartCar;
    private GameObject car1;
    private GameObject car2;

    public Rigidbody rb;

    public Button nextCar;
    public Button previousCar;
    private bool cantMakeMoreThenTwoCars;
    private bool cantMakeMoreThenTwoCars2;

    public float speed = 40;

    private void Awake()
    {
        ChangeCars1();
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        CloseTheChangeCarsButtons();
    }
    public void CloseTheChangeCarsButtons()
    {
        if (GameManager.instance.startTheGame)
        {
            nextCar.gameObject.SetActive(false);
            previousCar.gameObject.SetActive(false);
        }
    }
    public void ChangeCars1()
    {
        if (!cantMakeMoreThenTwoCars)
        {
            car1 = Instantiate(playerCarSelection[0], transform.position, Quaternion.identity);
            Destroy(car2);
            Destroy(firstStartCar);
            cantMakeMoreThenTwoCars = true;
            cantMakeMoreThenTwoCars2 = false;
        }
    }
    public void ChangeCars2()
    {
        if (!cantMakeMoreThenTwoCars2)
        {
            car2 = Instantiate(playerCarSelection[1], transform.position, Quaternion.identity);
            Destroy(car1);
            Destroy(firstStartCar);
            cantMakeMoreThenTwoCars2 = true;
            cantMakeMoreThenTwoCars = false;
        }
    }
}
