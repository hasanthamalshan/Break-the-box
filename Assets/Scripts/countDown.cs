using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countDown : MonoBehaviour
{
    public Text count; 
    int c = 3;
    void Start(){
        count.text = "3";
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown(){
        for(int i=0 ; i < c ; i++){
            count.text = (c - i).ToString();
          //  countsound.Play();
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(2);
    }

    
}
