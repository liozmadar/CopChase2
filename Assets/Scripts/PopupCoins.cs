using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCoins : MonoBehaviour
{
    private float destroyTimer;
    private Vector3 offSet = new Vector3(0, 30, 0);
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        destroyTimer = 2;
        transform.position = transform.position + offSet;
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += Vector3.up * Speed;
       // transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
    }
}
