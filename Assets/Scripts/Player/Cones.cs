using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cones : MonoBehaviour
{
    public static Cones instance;
    public GameObject cone;
    public GameObject coneCollected;
    public TextMeshProUGUI coneCountText;

    public float coneShowTimer = 3;
    private bool coneShowBool = true;

    public int coneCollectedCount;
    public bool allConesCollected;
    private int randomConeNumber = 30;

    private Vector3 randomPos;

    public int totalCoinsFromCones;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        coneCountText = GameObject.FindGameObjectWithTag("ConeCountText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startTheGame)
        {
            ConeSpawn();
            AllConesCollected();
        }
    }
    void ConeSpawn()
    {
        coneShowTimer -= Time.deltaTime;
        if (coneShowTimer < 0 && coneShowBool)
        {
            /*randomConeNumber = Random.Range(1, 2);
            for (int i = 0; i < randomConeNumber; i++)
            {
               
            }*/
            RandomConeLocatin();
            coneShowBool = false;
        }
        coneCountText.text = coneCollectedCount.ToString();// + "/" + randomConeNumber;
    }
    void RandomConeLocatin()
    {
        int randomPosX = Random.Range(-500, 500);
        int randomPosZ = Random.Range(-500, 500);
        randomPos = new Vector3(transform.position.x + randomPosX, -8, transform.position.z + randomPosZ);
        Instantiate(cone, randomPos, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cone")
        {
            Instantiate(coneCollected, other.transform.position, Quaternion.identity);
            Destroy(other);
            RandomConeLocatin();
            coneCollectedCount++;
            ScoreSystem.instance.totalScorePoints++;
            PlayerPrefs.SetInt("totalScorePoints", ScoreSystem.instance.totalScorePoints);
            totalCoinsFromCones += 10;
            Debug.Log(totalCoinsFromCones);
        }
    }
    public void AllConesCollected()
    {
        if (coneCollectedCount >= randomConeNumber)
        {
            allConesCollected = true;
        }
    }
}
