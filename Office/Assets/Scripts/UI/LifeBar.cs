using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeBar : MonoBehaviour
{
  

    public int health;
    public int NumOfLifes;

    public Image[] Lifes;
    public Sprite FullLife;
    public Sprite EmptyLife;


    bool gameHasEnded = false;
    public float restartDelay = 1f;
 
    void Update()
    {
        for (int i = 0; i < Lifes.Length; i++)
        {
            if (i < health)
                Lifes[i].sprite = FullLife;
            else
                Lifes[i].sprite = EmptyLife;


            // to not allow player adding more lifes than the lifebar limit
            if (i < NumOfLifes)
                Lifes[i].enabled = true;
            else
                Lifes[i].enabled = false;


        }

        isdead();
    }


    public void DecreaseLife()
    {
        health = health - 1;

    }

    public void isdead()
    {
        if (health == 0)
        {
            EndGame();
        }
    }


    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");

            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

 




}