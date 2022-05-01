using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    public GameObject[] hearts;
    public int hp = 3;
    public Menus loseMenu;

    public GameObject heartPickup;
    public float heartSpawnCooldown = 15f;
    public float heartSpawnCooldownRest = 15f;

    public Animator anim;

    void Start()
    {
        loseMenu = FindObjectOfType<Menus>();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        SpawnHearts();
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
        anim.SetTrigger("AddScore");
        HighScore();
    }

    public void LoseHP(int hplost)
    {
        hp -= hplost;
        if(hp == 2)
        {
            hearts[2].SetActive(false);
        }
        else if(hp == 1)
        {
            hearts[1].SetActive(false);
        }
        else if (hp == 0)
        {
            hearts[0].SetActive(false);
            loseMenu.GetComponent<Menus>().LoseMenu();
        }
    }

    public void AddHp()
    {
        if (hearts[1].activeInHierarchy == false && hearts[2].activeInHierarchy == false)
        {
            hearts[1].SetActive(true);
            hp += 1;
        }
        else if (hearts[2].activeInHierarchy == false)
        {
            hearts[2].SetActive(true);
            hp += 1;
        }
        else
            return;
    }

    public void SpawnHearts()
    {
        if(hearts[2].activeInHierarchy == false)
        {
            heartSpawnCooldown -= Time.deltaTime;
            if(heartSpawnCooldown <= 0)
            {
                Debug.Log("spawned heart");
                Vector3 randomSpawnHeart = new Vector3(Random.Range(-4.5f, 5), Random.Range(-3, 6), 0);
                Instantiate(heartPickup, randomSpawnHeart, gameObject.transform.rotation);
                heartSpawnCooldown = heartSpawnCooldownRest;
            }

        }
    }

    public void HighScore()
    {
        if(PlayerPrefs.GetInt("HighScore",0) < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
