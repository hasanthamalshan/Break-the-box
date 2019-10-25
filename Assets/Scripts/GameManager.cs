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
    int level;
    public static bool isGameOver = false;
    public static bool isPaused = false;

    private void Awake() {
        score = 0;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(){
        SceneManager.LoadScene(1);
    }
}
