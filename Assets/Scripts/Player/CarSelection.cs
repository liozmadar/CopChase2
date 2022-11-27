using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    public static CarSelection instance;
    public GameObject[] playerCarSelection;
    private int index;
    public GameObject firstStartCar;

    public Rigidbody rb;

    public Button nextCar;
    public Button previousCar;
    private bool cantMakeMoreThenTwoCars;

    public float speed = 40;

    private void Awake()
    {
        FirstCarStart();
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
    public void FirstCarStart()
    {
        if (!cantMakeMoreThenTwoCars)
        {
            cantMakeMoreThenTwoCars = true;
            firstStartCar = Instantiate(playerCarSelection[0], transform.position, Quaternion.identity);
        }
    }
    public void NextCarIndex()
    {
        if (playerCarSelection.Length > index+1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            index++;
            Instantiate(playerCarSelection[index], transform.position, Quaternion.identity);
        }
    }
    public void PreviousCarIndex()
    {
        if (index > 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            index--;
            Instantiate(playerCarSelection[index], transform.position, Quaternion.identity);
        }
    }
}
