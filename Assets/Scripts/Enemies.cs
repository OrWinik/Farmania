using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public ScoreManager loseHP;

    void Start()
    {
        loseHP = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("collsion");
        Destroy(this.gameObject);
        loseHP.GetComponent<ScoreManager>().LoseHP(1);
        FindObjectOfType<AudioManager>().play("Missed");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collider")
        {
            Destroy(this.gameObject);
        }
    }
}
