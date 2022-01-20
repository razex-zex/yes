using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static int scoreValue = 10;
    Text score;
    void Start()
    {
        scoreValue = 0;
        score = GetComponent<Text>();
    }

    
    void Update()
    {
        score.text = " " + scoreValue;
    }
}
