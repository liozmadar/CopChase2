using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenButtonMovement : MonoBehaviour
{
    public static ScreenButtonMovement instance;

    public bool pressingLeft;
    public bool pressingRight;

    public Button screenLeft;
    public Button screenRight;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        screenLeft = GameObject.FindGameObjectWithTag("ScreenLeft").GetComponent<Button>();
        screenRight = GameObject.FindGameObjectWithTag("ScreenRight").GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickLeftDown()
    {
        pressingLeft = true;
       // trailRenderer.enabled = true;
    }
    public void ClickRightDown()
    {
        pressingRight = true;
       // trailRenderer.enabled = true;
    }
    public void ClickLeftUp()
    {
        pressingLeft = false;
        // trailRenderer.enabled = false;
    }
    public void ClickRightUp()
    {
        pressingRight = false;
        //trailRenderer.enabled = false;
    }
}
