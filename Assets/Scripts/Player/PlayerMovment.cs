using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    public float angleSpeed;
    public Rigidbody rb;
    public int currntAngle;
    //
    public GameObject smokeEffect, fireEffect, explosionEffect;
    public float invincibleTime = 1;
    public int life = 10;

    public int currentLife;
    public float currentinvincibleTime;
    private bool isColliding;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AllMovment();
    }

    void AllMovment()
    {
        var v3 = transform.forward * speed;
        v3.y = rb.velocity.y;
        rb.velocity = v3;

        if (Input.GetMouseButton(0))
        {
            float x = Input.mousePosition.x;
            if (x < Screen.width / 2 && x > 0)
            {
                MoveLeft();
            }

            if (x > Screen.width / 2 && x < Screen.width)
            {
                MoveRight();
            }
        }     
        if (isColliding == true)
        {
            currentinvincibleTime -= Time.deltaTime;
            if (currentinvincibleTime <= 0)
            {
                //ReduceLife();

            }
        }
    }
    public void MoveLeft()
    {
        transform.Rotate(-Vector3.up * angleSpeed * Time.deltaTime);
    }
    public void MoveRight()
    {
        transform.Rotate(Vector3.up * angleSpeed * Time.deltaTime);
    }
}
