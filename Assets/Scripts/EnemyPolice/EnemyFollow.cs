using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    public float speed;
    public float slowSpeed;
    public float currentSpeed;

    public float angleSpeed;

    public NavMeshAgent navMesh;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        currentSpeed = slowSpeed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        AnotherMovment();
        Rotation();
        AllCopsGoAway();
        //TryMove();
        if (transform.position.y > 7)
        {
            currentSpeed = slowSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
    }
    private void Update()
    {

    }
    void AnotherMovment()
    {
        if (player != null)
        {
            //here is movement so the car can go up through gravity;
            Vector3 newPositon = transform.position + (transform.forward * currentSpeed * Time.deltaTime);
            rb.MovePosition(newPositon);

            //Player Auto move forward , and here is the movement for collision with other objects
            var v3 = transform.forward * currentSpeed;
            v3.y = rb.velocity.y;
            rb.velocity = v3;
            //
        }
    }
    void AllCopsGoAway()
    {
        if (Cones.instance.allConesCollected)
        {
            Debug.Log("now");
            var targetRotation = Quaternion.LookRotation(transform.position - player.transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, angleSpeed * Time.deltaTime);
        }
    }
    void Rotation()
    {
        if (!Cones.instance.allConesCollected)
        {
            var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, angleSpeed * Time.deltaTime);
        }
    }
}
