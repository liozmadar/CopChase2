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
    private void Awake()
    {
        screenLeft = GameObject.FindGameObjectWithTag("ScreenLeft").GetComponent<Button>();
        screenRight = GameObject.FindGameObjectWithTag("ScreenRight").GetComponent<Button>();
    }
    void Start()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {

      /*  var fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount <= 0)
        {
           // print("User has " + fingerCount + " finger(s) touching the screen");
            pressingLeft = false;
            pressingRight = false;
        }*/
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
