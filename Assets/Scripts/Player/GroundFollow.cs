using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == isActiveAndEnabled)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            var posX = player.transform.position.x;
            var posZ = player.transform.position.z;
            var newPos = new Vector3(posX, 0, posZ);
            gameObject.transform.position = newPos;
        }
    }
}
