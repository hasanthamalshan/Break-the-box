using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes_Normal : MonoBehaviour
{   
    public Transform topLeft;
    public Transform bottomRight;
    public GameObject[] spawnee;
    static bool isSpawnon;
    bool boxone;
    bool boxtwo;
    GameObject obj1;
    GameObject obj2;
       
    void Start(){
        HealthBar.healthloss = 2.5f;
        Vector3 Boxpos1 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj1 = Instantiate(spawnee[2],Boxpos1,Quaternion.identity);
        obj1.tag = "one";
        Vector3 Boxpos2 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj2 = Instantiate(spawnee[3],Boxpos2,Quaternion.identity);
        obj2.tag = "two";
        isSpawnon = false;
        boxone = false;
        boxtwo = false;
    }
    void Update()
    {   
        if (Input.GetMouseButtonDown(0) && !GameManager.isGameOver) {
         int num1 = Random.Range(0,8);
         int num2 = Random.Range(0,8);
         Vector2 pos = Input.mousePosition;
         Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null) {
                if( hitCollider.tag == "one"){
                    GameObject.Destroy(obj1); 
                    boxone = true; 
                }
                if( hitCollider.tag == "two"){
                    GameObject.Destroy(obj2); 
                    boxtwo = true;  
                }
                if(boxone && boxtwo){
                    isSpawnon = true; 
                    HealthBar.health = HealthBar.health + 50f; 
                    GameManager.score++;
                }
            }
            if(isSpawnon){
                Vector3 Boxpos1 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
                obj1 = Instantiate(spawnee[num1],Boxpos1,Quaternion.identity);
                obj1.tag = "one";
                Vector3 Boxpos2 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
                obj2 = Instantiate(spawnee[num2],Boxpos2,Quaternion.identity);
                obj2.tag = "two";
                isSpawnon = false;
                boxone = false;
                boxtwo = false;
            }
        }
        
    }
}
