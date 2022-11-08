using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public Transform target;
    public Transform arrow;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       // ArrowsPointer();
        ArrowsBodyCircle();
    }
    void ArrowsPointer()
    {
        transform.LookAt(target);
    }
    void ArrowsBodyCircle()
    {
        Vector3 dir = player.InverseTransformPoint(target.position);
        float a = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        a += 180;
        arrow.transform.localEulerAngles = new Vector3(0, 0, a);
    }
}
