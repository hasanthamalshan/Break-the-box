using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour{

    public Image healthbar;
    float maxhealth = 1000f;

    public static float healthloss;

    public static float health;

    public GameObject paused;
    public GameObject gameover;

    private void Start() {
        health = maxhealth;
        gameover.SetActive(false);
    }

    private void Update(){
       if(Input.GetKeyDown(KeyCode.Escape)){
            GameManager.isPaused = true;
            Time.timeScale = 0;
            paused.SetActive(true);
        }
        if(!GameManager.isPaused){
            healthbar.fillAmount = health / maxhealth ;
            health = health - healthloss;
                if(health < 400f){
                    healthbar.color = Color.red;
                }
                if(health <= 0){
                    GameManager.isGameOver = true;
                    gameover.SetActive(true);
                }
        }
    }

    public void resume(){
        GameManager.isPaused = false;
        Time.timeScale = 1;
        paused.SetActive(false);
    }
    public void restart(){
        GameManager.score = 0;
        Time.timeScale = 1;
        paused.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void mainmenu(){
        GameManager.isPaused = false;
        Time.timeScale = 1;
        paused.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
