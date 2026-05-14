using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreUpdate : MonoBehaviour
{
    public StepsTakenChecker CheckSteps;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    void Start()
    {
        if (scoreText == null)
        {
           
            scoreText = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CheckSteps == null || scoreText == null)
        {
            return;
        }

        // Check if the simulation has been won
        if (CheckSteps.simulationWon)
        {
            string target = CheckSteps.score.ToString();
            if (scoreText.text != target)
            {
                scoreText.text = "You win! Your score is: " + target;
            }
        }
    }
}

