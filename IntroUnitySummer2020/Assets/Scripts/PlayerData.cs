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

    public void Respawn()
    {
        currentHealth = 1.0f;
        currentScore = 0;

        UpdateScore();
        UpdateHealth();

        gameObject.transform.position = spawnPoint.position;
    }
}
