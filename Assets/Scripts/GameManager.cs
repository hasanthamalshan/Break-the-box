using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;

    public static bool isEasy;
    public static bool isNormal;
    public static bool isExpert;

    public GameObject mainmenu;
    public GameObject settingsmenu;
    public GameObject rankmenu;

    int level;
    public static bool isGameOver;
    public static bool isPaused;

    private void Awake() {
        score = 0;
        isGameOver = false;
        isPaused = false;
    }
    void Start()
    {
         mainmenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver){
            Debug.Log("game over");
        }   
    }

    public void startGame(){
        SceneManager.LoadScene(1);
    }
    public void aboutGame(){
        Debug.Log("about");
    }
    public void settingsGame(){
        mainmenu.SetActive(false);
        rankmenu.SetActive(false);
        settingsmenu.SetActive(true);
    }
    public void rankGame(){
        mainmenu.SetActive(false);
        settingsmenu.SetActive(false);
        rankmenu.SetActive(true);
    }
    
    public void toMainMenu(){
        mainmenu.SetActive(true);
        settingsmenu.SetActive(false);
        rankmenu.SetActive(false);
    }

    public void easyGame(){
        isEasy = true;
        isNormal = false;
        isExpert = false;
    }
    public void normalGame(){
        isEasy = false;
        isNormal = true;
        isExpert = false;
    }
    public void expertGame(){
        isEasy = false;
        isNormal = false;
        isExpert = true;
    }


}
