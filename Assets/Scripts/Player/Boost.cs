using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    public Image boostImage;

    float boostLevel = 0;
    float playerBoostSpeedTimer = 0;
    bool playerBoostSpeedBool;

    public float boostSpeed = 25;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startTheGame)
        {
            FillImageBoost();
            BoostAnim();
        }
    }
    void BoostAnim()
    {
        if (playerBoostSpeedBool)
        {
            playerBoostSpeedTimer += Time.deltaTime;
            if (playerBoostSpeedTimer > 3)
            {
                PlayerMovment.instance.boostFlame.SetActive(false);
                PlayerMovment.instance.boostFlame2.SetActive(false);
                PlayerMovment.instance.anim.SetBool("Boost", false);
                PlayerMovment.instance.currentSpeed = PlayerMovment.instance.speed;
                playerBoostSpeedTimer = 0;
                playerBoostSpeedBool = false;
            }
        }
    }
    void FillImageBoost()
    {
        boostLevel += Time.deltaTime / 10;
        boostImage.fillAmount = boostLevel;
        boostImage.color = Color.Lerp(Color.red, Color.green, boostLevel);
    }
    public void ClickBoost()
    {
        if (boostLevel >= 1)
        {
            boostLevel = 0;
            PlayerMovment.instance.currentSpeed = boostSpeed;
            playerBoostSpeedBool = true;
            PlayerMovment.instance.anim.SetBool("Boost",true);
            PlayerMovment.instance.boostFlame.SetActive(true);
            PlayerMovment.instance.boostFlame2.SetActive(true);
        }
    }
}
