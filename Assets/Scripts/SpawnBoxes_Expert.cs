using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes_Expert : MonoBehaviour
{   
    public Transform topLeft;
    public Transform bottomRight;
    public GameObject[] spawnee;
    static bool isSpawnon;
    bool boxone;
    bool boxtwo;
    bool boxthree;
    GameObject obj1;
    GameObject obj2;
    GameObject obj3;
       
    void Start(){
        Vector3 Boxpos1 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj1 = Instantiate(spawnee[2],Boxpos1,Quaternion.identity);
        obj1.tag = "one";
        Vector3 Boxpos2 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj2 = Instantiate(spawnee[3],Boxpos2,Quaternion.identity);
        obj2.tag = "two";
        Vector3 Boxpos3 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj3 = Instantiate(spawnee[3],Boxpos3,Quaternion.identity);
        obj3.tag = "three";
        isSpawnon = false;
        boxone = false;
        boxtwo = false;
        boxthree = false;
    }
    void Update()
    {   
        if (Input.GetMouseButtonDown(0)) {
         int num1 = Random.Range(0,8);
         int num2 = Random.Range(0,8);
         int num3 = Random.Range(0,8);
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
                if( hitCollider.tag == "three"){
                    GameObject.Destroy(obj3); 
                    boxthree = true;  
                }
                if(boxone && boxtwo && boxthree){
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
                Vector3 Boxpos3 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
                obj3 = Instantiate(spawnee[num2],Boxpos3,Quaternion.identity);
                obj3.tag = "three";
                isSpawnon = false;
                boxone = false;
                boxtwo = false;
                boxthree = false;
            }
        }
        
    }
}
