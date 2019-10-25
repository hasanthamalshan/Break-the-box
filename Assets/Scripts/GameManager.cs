using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;
    public GameObject easy;
    public GameObject normal;
    public GameObject expert;

    public GameObject mainmenu;
    public GameObject settingsmenu;
    public GameObject rankmenu;

    int level;
    public static bool isGameOver = false;
    public static bool isPaused = false;

    private void Awake() {
        score = 0;
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
}
