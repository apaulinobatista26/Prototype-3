using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

   

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript =
        GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
          
        if (!playerControllerScript.gameOver)
        {
          if(playerControllerScript.dash)
         {
           score +=2;
         }

         else 
         {
            score++;
         }
         Debug.Log("Score:" + score);
        }
         


    }
}
