using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUps : MonoBehaviour
{
    public ScoreManager addScore;
    public ScoreManager loseHP;
    public int scoreToAdd = 1;

    //clicks to destroy
    public PickUps[] clickArry = new PickUps [3];
    public int clicks = 0;

    public Animator animator;


    void Start()
    {
        addScore = FindObjectOfType<ScoreManager>();
        loseHP = FindObjectOfType<ScoreManager>();
        ClicksForAnimals();
    }

    private void OnMouseDown()
    {
        clicks -= 1;
        if (clicks >= 1)
        {
            animator.SetTrigger("Click");
            FindObjectOfType<AudioManager>().play("Click");
        }
        else if (clicks <= 0)
        {
            animator.SetTrigger("PickedUp");
            FindObjectOfType<AudioManager>().play("PickedUp");
            Destroy(this.gameObject,0.3f);
            addScore.GetComponent<ScoreManager>().AddScore(scoreToAdd);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collider")
        {
            Destroy(this.gameObject);
            loseHP.GetComponent<ScoreManager>().LoseHP(1);
            FindObjectOfType<AudioManager>().play("Missed");
        }
    }

    public void ClicksForAnimals()
    {
        
        if(gameObject.name == "chick(Clone)")
        {
            clicks = 1;
            scoreToAdd = 1;
        }
        else if(gameObject.name == "pig(Clone)")
        {
            clicks = 2;
            scoreToAdd = 5;
        }
        else if (gameObject.name == "cow(Clone)")
        {
            clicks = 3;
            scoreToAdd = 10;
        }
        else if (gameObject.name == "horse(Clone)")
        {
            clicks = 4;
            scoreToAdd = 15;
        }
    }
}
