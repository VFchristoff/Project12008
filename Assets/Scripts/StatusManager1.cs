using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StatusManager1 : MonoBehaviour
{
    //Game states
    //
    private enum GameState { Menu, Playing, GameOver }
    private GameState currentState;
    //Menu variables
    public string nameRobot;
    //Robot Status sprites
    //var Energy
    public SpriteRenderer barFullEnergy;
    public SpriteRenderer barAlmostFullEnergy;
    public SpriteRenderer barAlmostEmptyEnergy;
    public SpriteRenderer barEmptyEnergy;
    public SpriteRenderer barDeadEnergy;

    //var Satisfied
    //
    public SpriteRenderer barEmptySatisfied;
    public SpriteRenderer barFullSatisfied;
    public SpriteRenderer barAlmostFullSatisfied;
    public SpriteRenderer barAlmostEmptySatisfied;
    public SpriteRenderer barDeadSatisfied;

    //var Amused
    //
    public SpriteRenderer barFullAmused;
    public SpriteRenderer barEmptyAmused;
    public SpriteRenderer barAlmostEmptyAmused;
    public SpriteRenderer barAlmostFullAmused;
    public SpriteRenderer barDeadAmused;

    //Robot Status variables
    //var 
    public int intEnergy;
    public int intSatisfied;
    public int intAmused;

    //robotSprites
    //
    public SpriteRenderer robotHappy;
    public SpriteRenderer robotAnnoyed;
    public SpriteRenderer robotNotOkay;
    public SpriteRenderer robotSad;
    public SpriteRenderer robotDead;

    //Timer variables
    //
    public float interval = 10f;
    private float timer;
    
    void Start()
    {
        timer = Random.Range(5f, 10f);
        currentState = GameState.Playing;
        if (currentState == GameState.Playing) {
            Time.timeScale = 1f;
        }
        intEnergy = 4;
        intSatisfied = 3;
        intAmused = 4;
    }
    
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            RandomNumberStatus();
            timer = Random.Range(0.2f, 2f);
        }

        if (currentState == GameState.Playing)
        {
            UpdateStatus();
            UpdateRobotSprites();
        }
        Debug.Log("Time: " + timer);
        Debug.Log("Int Energy: " + intEnergy);
        Debug.Log("Int Amused: " + intAmused);
        Debug.Log("Int Satisfied: " + intSatisfied);
    }

    public void Charge() {
        intEnergy = intEnergy + 1;
        UpdateStatus();
    }

    public void Happy()
    {
        intAmused = intAmused + 1;
        UpdateStatus();
    }

    public void Feed()
    {
        intSatisfied = intSatisfied + 1;
        UpdateStatus();
    }

    void UpdateStatus()
    {
        UpdateStatusAmusedSpriteRenderers();
        UpdateStatusEnergySpriteRenderers();
        UpdateStatusSatisfiedSpriteRenderers();
        UpdateRobotSprites();
    }

    public void UpdateRobotSprites() {
        if (intEnergy == 0|| intAmused == 0 || intSatisfied == 0)
        {
            robotAnnoyed.enabled = false;
            robotHappy.enabled = false;
            robotSad.enabled = false;
            robotNotOkay.enabled = false;
            robotDead.enabled = true;
        }
        else if (intEnergy == 1 || intAmused == 1 || intSatisfied == 1)
        {
            robotAnnoyed.enabled = false;
            robotHappy.enabled = false;
            robotSad.enabled = true;
            robotNotOkay.enabled = false;
            robotDead.enabled = false;
        }
        else if (intEnergy == 2 || intAmused == 2 || intSatisfied == 2)
        {
            robotAnnoyed.enabled = false;
            robotHappy.enabled = false;
            robotSad.enabled = false;
            robotNotOkay.enabled = true;
            robotDead.enabled = false;
        }
        else if (intEnergy == 3 || intAmused == 3 || intSatisfied == 3)
        {
            robotAnnoyed.enabled = true;
            robotHappy.enabled = false;
            robotSad.enabled = false;
            robotNotOkay.enabled = false;
            robotDead.enabled = false;
        }
        else if (intEnergy == 4 || intAmused == 4 || intSatisfied == 4)
        {
            robotAnnoyed.enabled = false;
            robotHappy.enabled = true;
            robotSad.enabled = false;
            robotNotOkay.enabled = false;
            robotDead.enabled = false;
        }
    }

    public void UpdateStatusEnergySpriteRenderers()
    {
        if (intEnergy == 0)
        {
            barEmptyEnergy.enabled = false;
            barFullEnergy.enabled = false;
            barAlmostFullEnergy.enabled = false;
            barAlmostEmptyEnergy.enabled = false;
            barDeadEnergy.enabled = true;
        }
        else if (intEnergy == 1)
        {
            barAlmostEmptyEnergy.enabled = false;
            barFullEnergy.enabled = false;
            barEmptyEnergy.enabled = true;
            barAlmostFullEnergy.enabled = false;
            barDeadEnergy.enabled = false;
        }
        else if (intEnergy == 2)
        {
            barAlmostFullEnergy.enabled = false;
            barFullEnergy.enabled = false;
            barEmptyEnergy.enabled = false;
            barAlmostEmptyEnergy.enabled = true;
            barDeadEnergy.enabled = false;
        }
        else if (intEnergy == 3)
        {
            barFullEnergy.enabled = false;
            barEmptyEnergy.enabled = false;
            barAlmostFullEnergy.enabled = true;
            barAlmostEmptyEnergy.enabled = false;
            barDeadEnergy.enabled = false;
        }
        else if (intEnergy == 4)
        {
            barFullEnergy.enabled = true;
            barEmptyEnergy.enabled = false;
            barAlmostFullEnergy.enabled = false;
            barAlmostEmptyEnergy.enabled = false;
            barDeadEnergy.enabled = false;
        }
    }
    public void UpdateStatusSatisfiedSpriteRenderers()
    {
        if (intSatisfied == 0)
        {
            barEmptySatisfied.enabled = false;
            barFullSatisfied.enabled = false;
            barAlmostFullSatisfied.enabled = false;
            barAlmostEmptySatisfied.enabled = false;
            barDeadSatisfied.enabled = true;
        }
        else if (intSatisfied == 1)
        {
            barAlmostEmptySatisfied.enabled = false;
            barFullSatisfied.enabled = false;
            barEmptySatisfied.enabled = true;
            barAlmostFullSatisfied.enabled = false;
            barDeadSatisfied.enabled = false;
        }
        else if (intSatisfied == 2)
        {
            barAlmostFullSatisfied.enabled = false;
            barFullSatisfied.enabled = false;
            barEmptySatisfied.enabled = false;
            barAlmostEmptySatisfied.enabled = true;
            barDeadSatisfied.enabled = false;
        }
        else if (intSatisfied == 3)
        {
            barFullSatisfied.enabled = false;
            barEmptySatisfied.enabled = false;
            barAlmostFullSatisfied.enabled = true;
            barAlmostEmptySatisfied.enabled = false;
            barDeadSatisfied.enabled = false;
        }
        else if (intSatisfied == 4)
        {
            barFullSatisfied.enabled = true;
            barEmptySatisfied.enabled = false;
            barAlmostFullSatisfied.enabled = false;
            barAlmostEmptySatisfied.enabled = false;
            barDeadSatisfied.enabled = false;
        }
    }
    public void UpdateStatusAmusedSpriteRenderers()
    {
        if (intAmused == 0)
        {
            barEmptyAmused.enabled = false;
            barFullAmused.enabled = false;
            barAlmostFullAmused.enabled = false;
            barAlmostEmptyAmused.enabled = false;
            barDeadAmused.enabled = true;
        }
        else if (intAmused == 1)
        {
            barAlmostEmptyAmused.enabled = false;
            barFullAmused.enabled = false;
            barEmptyAmused.enabled = true;
            barAlmostFullAmused.enabled = false;
            barDeadAmused.enabled = false;
        }
        else if (intAmused == 2)
        {
            barAlmostFullAmused.enabled = false;
            barFullAmused.enabled = false;
            barEmptyAmused.enabled = false;
            barAlmostEmptyAmused.enabled = true;
            barDeadAmused.enabled = false;
        }
        else if (intAmused == 3)
        {
            barFullAmused.enabled = false;
            barEmptyAmused.enabled = false;
            barAlmostFullAmused.enabled = true;
            barAlmostEmptyAmused.enabled = false;
            barDeadAmused.enabled = false;
        }
        else if (intAmused == 4)
        {
            barFullAmused.enabled = true;
            barEmptyAmused.enabled = false;
            barAlmostFullAmused.enabled = false;
            barAlmostEmptyAmused.enabled = false;
            barDeadAmused.enabled = false;
        }
    }

    public void RandomNumberStatus() {
        //1 = intSatisfied
        //2 = intEnergy
        //3 = intAmused

        int sortedNumber = Random.Range(1, 3);
        if (sortedNumber == 1) {
            intSatisfied = intSatisfied - 1;
            if (intSatisfied == 0)
            {
                currentState = GameState.GameOver;
                Time.timeScale = 0f;
                SceneManager.LoadScene("GameOver");
                intAmused = 4;
                intSatisfied = 4;
                intEnergy = 4;

            }
        } else if (sortedNumber == 2) {
            intEnergy = intEnergy - 1;
            if (intEnergy == 0)
            {
                currentState = GameState.GameOver;
                Time.timeScale = 0f;
                SceneManager.LoadScene("GameOver");
                intAmused = 4;
                intSatisfied = 4;
                intEnergy = 4;
            }

        } else if (sortedNumber == 3) {
            intAmused = intAmused - 1;
            if (intEnergy == 0)
            {
                currentState = GameState.GameOver;
                Time.timeScale = 0f;
                SceneManager.LoadScene("GameOver");
                intAmused = 4;
                intSatisfied = 4;
                intEnergy = 4;
            }
        }
    }
}