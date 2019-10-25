using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes_Easy : MonoBehaviour
{   
    public Transform topLeft;
    public Transform bottomRight;
    public GameObject[] spawnee;
    static bool isSpawnon;
    GameObject obj;
       
    void Start(){
        HealthBar.healthloss = 5f;
        Vector3 Boxpos = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj = Instantiate(spawnee[2],Boxpos,Quaternion.identity);
        isSpawnon = false;
    }
    void Update()
    {   
        if (Input.GetMouseButtonDown(0) && !GameManager.isGameOver) {
         int num = Random.Range(0,8);
         Vector2 pos = Input.mousePosition;
         Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null) {
                GameObject.Destroy(obj); 
                HealthBar.health = HealthBar.health + 50f; 
                GameManager.score++;
                isSpawnon = true; 
            }
            if(isSpawnon){
                Vector3 Boxpos = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
                obj = Instantiate(spawnee[num],Boxpos,Quaternion.identity);
                isSpawnon = false;
            }
        }
        
    }
}
