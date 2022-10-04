using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 CameraPos = new Vector3(player.transform.position.x,transform.position.y, player.transform.position.z - 200);
        // transform.position = CameraPos;
        CameraMove();
    }
    void CameraMove()
    {
        float PosX = player.transform.position.x;
        float PosZ = player.transform.position.z -180;

        transform.position = new Vector3(PosX, transform.position.y, PosZ);
    }
}
