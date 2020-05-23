using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public TMPro.TMP_Text scoreValue;
    public Slider healthBarUI;

    public Transform spawnPoint;
    public GameObject gameUI;
    public GameObject gameOver;

    private int currentScore = 0;
    private float currentHealth = 1.0f;

    public void ChangeScore()
    {
        currentScore++;
        UpdateScore();

    }

    public void HitObstacle(float damage)
    {
        currentHealth -= damage;
        UpdateHealth();

        if (currentHealth <= 0.0f)
        {
            gameUI.SetActive(false);
            gameOver.SetActive(true);
        }
    }

    private void UpdateScore()
    {
        scoreValue.text = currentScore.ToString();
    }

    private void UpdateHealth()
    {
        healthBarUI.value = currentHealth;
    }

    public bool isGameOver()
    {
        return (currentHealth <= 0.0f);
    }

    private void RespawnGems()
    {
        //FIndObjectsOfType is really slow but it's an easy way to get all the gem spawners
        //Maybe I'll teach how to do this with a Spawn Manager
        GemSpawner[] spawners = FindObjectsOfType<GemSpawner>();

        foreach (GemSpawner spawner in spawners)
        {
            spawner.Spawn();
        }
    }

    public void Respawn()
    {
        currentHealth = 1.0f;
        currentScore = 0;

        UpdateScore();
        UpdateHealth();
        RespawnGems();

        gameObject.transform.position = spawnPoint.position;
    }
}
