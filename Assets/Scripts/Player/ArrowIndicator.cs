using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArrowIndicator : MonoBehaviour
{
    private Image image;
    public Transform target;
    private TextMeshProUGUI meter;
    public Vector3 offSet;
    public Vector3 offSetMeter;

    public Image imagePre;
    public TextMeshProUGUI meterPre;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        image = Instantiate(imagePre, transform.position, Quaternion.identity);
        meter = Instantiate(meterPre, transform.position, Quaternion.identity);

        image.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        meter.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        Indicator();
        IndicatorMeter();
    }
    public void Indicator()
    {
        float minX = image.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = image.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;


        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position + offSet);

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        image.transform.position = pos;
        meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
    }
    public void IndicatorMeter()
    {
        float minX = meter.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = meter.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;


        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position + offSetMeter);

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        meter.transform.position = pos;
    }
}
