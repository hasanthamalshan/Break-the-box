using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLoad : MonoBehaviour
{
    public GameObject easy;
    public GameObject normal;
    public GameObject expert;

    private void Awake() {
        if(GameManager.isEasy){
            easy.SetActive(true);
            normal.SetActive(false);
            expert.SetActive(false);
        }
        if(GameManager.isNormal){
            easy.SetActive(false);
            normal.SetActive(true);
            expert.SetActive(false);
        }
        if(GameManager.isExpert){
            easy.SetActive(false);
            normal.SetActive(false);
            expert.SetActive(true);
        }
    }
}
