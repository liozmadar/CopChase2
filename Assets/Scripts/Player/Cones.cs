using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cones : MonoBehaviour
{
    public GameObject cone;
    public GameObject coneCollected;
    public TextMeshProUGUI coneCountText;

    public float coneShowTimer = 3;
    private bool coneShowBool = true;
    public int coneCollectedCount;

    private Vector3 randomPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Collect.instance.startTheGame)
        {
            ConeSpawn();
        }
    }
    void ConeSpawn()
    {
        coneShowTimer -= Time.deltaTime;
        if (coneShowTimer < 0 && coneShowBool)
        {
            RandomConeLocatin();
            RandomConeLocatin();
            RandomConeLocatin();
            coneShowBool = false;
        }
        coneCountText.text = coneCollectedCount.ToString() + "/3";
    }
    void RandomConeLocatin()
    {
        int randomPosX = Random.Range(-500, 500);
        int randomPosZ = Random.Range(-500, 500);
        randomPos = new Vector3(transform.position.x + randomPosX, -8, transform.position.z + randomPosZ);
        Instantiate(cone, transform.position + randomPos, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cone")
        {
            Instantiate(coneCollected, other.transform.position, Quaternion.identity);
            var destroyTheCone = other.gameObject.GetComponent<ArrowIndicator>();
            destroyTheCone.DestroyImageAndMeter();
            Destroy(other);
            coneCollectedCount++;
        }
    }
}
