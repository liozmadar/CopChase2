using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundOrb : MonoBehaviour
{
    public GravityOrbit gravity;
    private Rigidbody rb;
    public float rotationSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravity = GameObject.FindGameObjectWithTag("GroundFloor").GetComponent<GravityOrbit>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (gravity)
        {
            Vector3 gravityUp = Vector3.zero;
            gravityUp = (transform.position - gravity.transform.position).normalized;
            Vector3 localUp = transform.up;
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.AddForce((-gravityUp * gravity.gravity) * rb.mass);
        }
    }
}
