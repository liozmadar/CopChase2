using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    public Image boostImage;

    float boostLevel = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FillImageBoost();
    }
    void FillImageBoost()
    {
        boostLevel += Time.deltaTime / 10;
        boostImage.fillAmount = boostLevel;
    }
    public void ClickBoost()
    {
        if (boostLevel >= 1)
        {
            boostLevel = 0;
        }
    }

}
