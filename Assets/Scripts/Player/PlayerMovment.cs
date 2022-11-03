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

    private bool pressingLeft;
    private bool pressingRight;
    private bool winGameCantMove;

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
        if (!winGameCantMove)
        {
            AllMovment();
        }
        WinDrift();
    }

    void AllMovment()
    {
        //Player Auto move forward
        var v3 = transform.forward * currentSpeed;
        v3.y = rb.velocity.y;
        rb.velocity = v3;

        //Invincible timer
        currentinvincibleTime -= Time.deltaTime;

        //The old movement
        //PlayerMovement();

        //The new movement
        PlayerMovementButtons();
    }
    // Button event
    public void ClickLeftDown()
    {
        pressingLeft = true;
    }
    public void ClickRightDown()
    {
        pressingRight = true;
    }
    public void ClickLeftUp()
    {
        pressingLeft = false;
    }
    public void ClickRightUp()
    {
        pressingRight = false;
    }
    //;
    void PlayerMovement()
    {
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
    }
    void PlayerMovementButtons()
    {
        if (pressingLeft)
        {
            MoveLeft();
        }
        else if (pressingRight)
        {
            MoveRight();
        }
        else return;
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
        Collect.instance.startTheGame = true;
    }
    public void MoveRight()
    {
        transform.Rotate(Vector3.up * angleSpeed * Time.deltaTime);
        Collect.instance.startTheGame = true;
    }
    void WinDrift()
    {
        if (Cones.instance.allConesCollected)
        {
            anim.SetBool("WinDrift",true);
            anim.SetBool("Boost", false);
            winGameCantMove = true;
            Debug.Log("drift"); 
        }
    }
}
