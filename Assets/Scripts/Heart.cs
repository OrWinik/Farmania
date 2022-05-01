using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public ScoreManager gm;

    public void Start()
    {
        gm = FindObjectOfType<ScoreManager>();
    }

    public void OnMouseDown()
    {
        Destroy(this.gameObject);
        gm.GetComponent<ScoreManager>().AddHp();
    }
}
