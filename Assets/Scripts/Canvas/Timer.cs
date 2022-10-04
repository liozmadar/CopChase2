using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timer;
    public int timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        timerText = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timerText++;
            timer = 1;
        }
        textMesh.text = timerText.ToString();
      
    }
}
