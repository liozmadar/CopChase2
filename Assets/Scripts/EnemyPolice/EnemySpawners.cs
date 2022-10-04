using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    public GameObject EnemyPolice;
    public GameObject EnemyPoliceLevel2;
    public GameObject EnemyPoliceLevel3;
    public GameObject[] EnemySpawnPoints;
    public float timer = 1;
    //   
    public int EnemyPoliceTimerLevels;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPoliceTimerLevels = GameObject.Find("CanvasManager").GetComponent<Timer>().timerText;
        // Debug.Log(EnemyPoliceTimerLevels);
   
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (EnemyPoliceTimerLevels < 10)
            {
                EnemySpawnLevel2();
                timer = 1;
            }
            else if (EnemyPoliceTimerLevels > 10)
            {
                EnemySpawnLevel3();
                timer = 1;
            }
            else if (EnemyPoliceTimerLevels > 20)
            {
                
                timer = 1;
                EnemySpawn();
            }

        }      
    }
    void EnemySpawn()
    {
        int RandomPoint = Random.Range(0, EnemySpawnPoints.Length);
        Instantiate(EnemyPolice, EnemySpawnPoints[RandomPoint].transform.position, Quaternion.identity);
        
    }
    void EnemySpawnLevel2()
    {
        int RandomPoint = Random.Range(0, EnemySpawnPoints.Length);
        Instantiate(EnemyPoliceLevel2, EnemySpawnPoints[RandomPoint].transform.position, Quaternion.identity);
    }
    void EnemySpawnLevel3()
    {
        int RandomPoint = Random.Range(0, EnemySpawnPoints.Length);
        Instantiate(EnemyPoliceLevel3, EnemySpawnPoints[RandomPoint].transform.position, Quaternion.identity);
    }

}
