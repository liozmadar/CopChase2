using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    public static PlayerMovment instance;
    public float speed;
    public float currentSpeed;
    public float angleSpeed;
    private Rigidbody rb;
    public Animator anim;
    //
    public GameObject smokeEffect, fireEffect, explosionEffect, boostFlame, boostFlame2;
    public float invincibleTime = 1;
    public int life = 10;

    public int currentLife;
    public float currentinvincibleTime;
    private bool stopCheckIfCollide = true;

    public Button screenLeft;
    public Button screenRight;
    private bool clickRight;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        AllMovment();
    }

    void AllMovment()
    {
        var v3 = transform.forward * currentSpeed;
        v3.y = rb.velocity.y;
        rb.velocity = v3;

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
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

        currentinvincibleTime -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyPolice" && stopCheckIfCollide)
        {
            if (currentinvincibleTime <= 0)
            {
                currentinvincibleTime = 1;
                life--;
                if (life < 3)
                {
                    smokeEffect.SetActive(true);
                }
                if (life < 1)
                {
                    fireEffect.SetActive(true);
                }
                if (life <= 0)
                {
                    GameObject ExplosionPrefab = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                    Destroy(ExplosionPrefab, 2);
                    for (int a = 0; a < 1; a++)
                    {
                        transform.GetChild(a).gameObject.SetActive(false);
                    }
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    smokeEffect.SetActive(false);
                    fireEffect.SetActive(false);
                    stopCheckIfCollide = false;
                }
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
