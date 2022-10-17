using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject cone;

    public float coneShowTimer = 3;
    private bool coneShowBool = true;

    private Vector3 randomPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coneShowTimer -= Time.deltaTime;
        if (coneShowTimer < 0 && coneShowBool)
        {
            RandomLocatin();
            RandomLocatin();
            RandomLocatin();
            coneShowBool = false;
        }
    }
    void RandomLocatin()
    {
        int randomPosX = Random.Range(-200,200);
        int randomPosZ = Random.Range(-200,200);
        randomPos = new Vector3(transform.position.x + randomPosX, -8, transform.position.z + randomPosZ);
        Instantiate(cone, transform.position + randomPos, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cone")
        {
            Destroy(other);
        }
    }
}
