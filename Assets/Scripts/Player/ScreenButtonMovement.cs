using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenButtonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickLeftDown()
    {
        PlayerMovment.instance.pressingLeft = true;
        PlayerMovment.instance.trailRenderer.enabled = true;
    }
    public void ClickRightDown()
    {
        PlayerMovment.instance.pressingRight = true;
        PlayerMovment.instance.trailRenderer.enabled = true;
    }
    public void ClickLeftUp()
    {
        PlayerMovment.instance.pressingLeft = false;
        PlayerMovment.instance.trailRenderer.enabled = false;
    }
    public void ClickRightUp()
    {
        PlayerMovment.instance.pressingRight = false;
        PlayerMovment.instance.trailRenderer.enabled = false;
    }
}
