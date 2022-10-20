using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{
    public static Collect instance;
    // Cone spawn
    public GameObject cone;
    public GameObject coneCollected;
    public TextMeshProUGUI coneCountText;

    public float coneShowTimer = 3;
    private bool coneShowBool = true;
    public int coneCollectedCount;

    private Vector3 randomPos;
    //;

    // Cops spawn
    public GameObject[] EnemySpawnPoints;
    public float timer = 1;

    public GameObject cop1;
    public GameObject cop2;
    public GameObject cop3;

    public TextMeshProUGUI copsCountText;
    private int copsCountNumber = 1;
    //;

    // Tuttorial
    public bool startTheGame;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTheGame)
        {
            ConeSpawn();
            SpawnCop();
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
        int randomPosX = Random.Range(-200, 200);
        int randomPosZ = Random.Range(-200, 200);
        randomPos = new Vector3(transform.position.x + randomPosX, -8, transform.position.z + randomPosZ);
        Instantiate(cone, transform.position + randomPos, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cone")
        {
            Instantiate(coneCollected, other.transform.position, Quaternion.identity);
            Destroy(other);
            coneCollectedCount++;
        }
    }
    void SpawnCop()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            int RandomPoint = Random.Range(0, EnemySpawnPoints.Length);
            if (Timer.instance.timerText < 10)
            {
                Instantiate(cop1, EnemySpawnPoints[RandomPoint].transform.position, Quaternion.identity);
            }
            else if (Timer.instance.timerText > 10 && Timer.instance.timerText < 20)
            {
                Instantiate(cop2, EnemySpawnPoints[RandomPoint].transform.position, Quaternion.identity);
            }
            else if (Timer.instance.timerText > 20)
            {
                Instantiate(cop3, EnemySpawnPoints[RandomPoint].transform.position, Quaternion.identity);
            }
            timer = 1;

            copsCountNumber++;
            copsCountText.text = copsCountNumber.ToString();
        }
    }
}
