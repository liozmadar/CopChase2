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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FillImageBoost();
        if (playerBoostSpeedBool)
        {
            playerBoostSpeedTimer += Time.deltaTime;
            if (playerBoostSpeedTimer > 3)
            {
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
            PlayerMovment.instance.currentSpeed = 50;
            playerBoostSpeedBool = true;
            PlayerMovment.instance.anim.SetTrigger("Boost");
        }
    }

}
