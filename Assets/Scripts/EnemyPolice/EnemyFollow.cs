using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    public float speed;
    public float angleSpeed;

    public NavMeshAgent navMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {      
        AnotherMovment();
    }
    private void Update()
    {
        if (transform.position.y > 6)
        {
            speed = 10;
        }
        else speed = 35;
    }
    void AnotherMovment()
    {
        if (player !=null)
        {
        Vector3 pointTarget = transform.position - player.transform.position;
        pointTarget.Normalize();

        float value = Vector3.Cross(pointTarget, transform.forward).y;
        rb.angularVelocity = angleSpeed * value * new Vector3(0, 1, 0);
        //rb.velocity = transform.forward * speed;
        //
        var v3 = transform.forward * speed;
        v3.y = rb.velocity.y;
        rb.velocity = v3;
        //
        }
    }
}
