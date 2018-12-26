using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    public float health;
    public Text healthText;
    public int laps;
    public Text YouLoseBox;
    public Text YouWinBox;
    public Text gameOverBox;
    public Text resetBox;
    public Text exitBox;
    public Image gameOverPanel;
    //public GameObject car;

    private bool damaged = false, completed = false;
    public bool gameEnded = false;

    private int currentLap = -1;

    // Use this for initialization
    void Start(){
        Time.timeScale = 1;

        YouLoseBox.enabled = false;
        YouWinBox.enabled = false;
        gameOverBox.enabled = false;
        resetBox.enabled = false;
        exitBox.enabled = false;
        gameOverPanel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //I read that this suppose to work once the game is build.
        if (gameEnded && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        damaged = false;
        completed = false;
    }

    public void Damage(int amount)
    {

        if (damaged || gameEnded)
            return;
        damaged = true;

        health -= amount;
        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            //Game over
            //You Lose
            YouLoseBox.enabled = true;
            gameOverPanel.enabled = true;
            Time.timeScale = 0;
            gameOverBox.enabled = true;
            resetBox.enabled = true;
            exitBox.enabled = true;
            gameEnded = true;
            //DestroyGameObject ();
        }
    }

    //	public void DestroyGameObject() {
    //		Destroy (gameObject);
    //	}
    public void CompleteLap()
    {

        if (completed || gameEnded)
            return;

        completed = true;

        ++currentLap;

        if (laps <= currentLap)
        {
            //Game over
            //You Win
            YouWinBox.enabled = true;
            gameOverPanel.enabled = true;
            gameEnded = true;
            gameOverBox.enabled = true;
            resetBox.enabled = true;
            exitBox.enabled = true;
        }
    }
}
