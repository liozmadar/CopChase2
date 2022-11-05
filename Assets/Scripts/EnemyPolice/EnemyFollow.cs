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
        Rotation();
    }
    private void Update()
    {
        if (transform.position.y > 6)
        {
            //  speed = 35;
        }
        //else speed = 35;
    }
    void AnotherMovment()
    {
        if (player != null)
        {
            //here is movement so the car can go up through gravity;
            Vector3 newPositon = transform.position + (transform.forward * speed * Time.deltaTime);
            rb.MovePosition(newPositon);

            //Player Auto move forward , and here is the movement for collision with other objects
            var v3 = transform.forward * speed;
            v3.y = rb.velocity.y;
            rb.velocity = v3;
            //
        }
    }
    void Rotation()
    {
        var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, angleSpeed * Time.deltaTime);
    }
}
