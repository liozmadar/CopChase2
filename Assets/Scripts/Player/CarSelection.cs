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
        // ObjectMoveWithTheScreen();
    }
    void ObjectMoveWithTheScreen()
    {
        //here is movement so the car can go up through gravity;
        Vector3 newPositon = transform.position + (transform.forward * speed * Time.deltaTime);
        rb.MovePosition(newPositon);

        //Player Auto move forward , and here is the movement for collision with other objects
        var v3 = transform.forward * speed;
        v3.y = rb.velocity.y;
        rb.velocity = v3;
        //
    }
    public void ChangeCars1()
    {
        if (!cantMakeMoreThenTwoCars)
        {
            Debug.Log("Here");
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
            Debug.Log("Here2");
            car2 = Instantiate(playerCarSelection[1], transform.position, Quaternion.identity);
            Destroy(car1);
            Destroy(firstStartCar);
            cantMakeMoreThenTwoCars2 = true;
            cantMakeMoreThenTwoCars = false;
        }
    }
}
