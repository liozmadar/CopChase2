using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDestroyed : MonoBehaviour
{
    public float maxLife = 10;
    public float currentLife;
    public float invicTime = 1;

    public GameObject explosion;
    public GameObject fire;
    public GameObject smoke;

    public GameObject popupCoins;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        invicTime -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "EnemyPolice")
        {
            if (invicTime < 0)
            {
                ReduceLife();
                invicTime = 1;
            }
        }
    }
    void ReduceLife()
    {
        currentLife--;
        if (currentLife == 3)
        {
            fire.gameObject.SetActive(true);
            smoke.gameObject.SetActive(true);
        }
        else if (currentLife == 0)
        {
            GameObject ExplosionPrefab = Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(ExplosionPrefab, 2);
            Destroy(gameObject, 5);
            GameManager.instance.copsDestroyedNumber++;
            Collect.instance.copsCountNumber--;
            if (gameObject.name == "Cop1(Clone)")
            {
                if (popupCoins)
                {
                    int coinsNumber = 10;
                    CanvasManager.instance.coinsFromCops += coinsNumber;
                    var popCoins = Instantiate(popupCoins, transform.position, Quaternion.identity);
                    popCoins.GetComponent<TextMeshPro>().text = "<color=orange>+" + coinsNumber + "</color>";
                }
            }
            else if (gameObject.name == "Cop2(Clone)")
            {
                if (popupCoins)
                {
                    int coinsNumber = 20;
                    CanvasManager.instance.coinsFromCops += coinsNumber;
                    var popCoins = Instantiate(popupCoins, transform.position, Quaternion.identity);
                    popCoins.GetComponent<TextMeshPro>().text = "<color=orange>+" + coinsNumber + "</color>";
                }
            }
            else if (gameObject.name == "Cop3(Clone)")
            {
                if (popupCoins)
                {
                    int coinsNumber = 30;
                    CanvasManager.instance.coinsFromCops += coinsNumber;
                    var popCoins = Instantiate(popupCoins, transform.position, Quaternion.identity);
                    popCoins.GetComponent<TextMeshPro>().text = "<color=orange>+" + coinsNumber + "</color>";
                }
            }
        }
    }
}
