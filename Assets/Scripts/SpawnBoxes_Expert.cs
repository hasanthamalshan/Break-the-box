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

    Vector3 sparkPos1;
    Vector3 sparkPos2;
    Vector3 sparkPos3;

    public GameObject sparkle;
    Color sparkColor1;
    Color sparkColor2;
    Color sparkColor3;
       
    void Start(){
        sparkle.SetActive(false);
        HealthBar.healthloss = 2f;

        Vector3 Boxpos1 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj1 = Instantiate(spawnee[2],Boxpos1,Quaternion.identity);
        obj1.tag = "one";
        sparkPos1 = Boxpos1;
        sparkColor1 = new Color(0.0549f, 0.9098f, 0.1098f, 1f);

        Vector3 Boxpos2 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj2 = Instantiate(spawnee[3],Boxpos2,Quaternion.identity);
        obj2.tag = "two";
        sparkPos2 = Boxpos2;
        sparkColor2 = new Color(0.7176f, 0.9686f, 0.0196f, 1f);

        Vector3 Boxpos3 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj3 = Instantiate(spawnee[4],Boxpos3,Quaternion.identity);
        obj3.tag = "three";
        sparkPos3 = Boxpos3;
        sparkColor3 = new Color(0.9686f, 0.3215f, 0.0196f, 1f);

        isSpawnon = false;
        boxone = false;
        boxtwo = false;
        boxthree = false;
    }
    void Update()
    {   
        if (Input.GetMouseButtonDown(0) && !GameManager.isGameOver && !GameManager.isPaused) {
         int num1 = Random.Range(0,8);
         int num2 = Random.Range(0,8);
         int num3 = Random.Range(0,8);
         Vector2 pos = Input.mousePosition;
         Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null) {
                if( hitCollider.tag == "one"){
                    GameObject.Destroy(obj1); 
                    emitEffect(sparkColor1 , sparkPos1); 
                    boxone = true; 
                }
                if( hitCollider.tag == "two"){
                    GameObject.Destroy(obj2); 
                    emitEffect(sparkColor2 , sparkPos2); 
                    boxtwo = true;  
                }
                if( hitCollider.tag == "three"){
                    GameObject.Destroy(obj3); 
                    emitEffect(sparkColor3 , sparkPos3); 
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
                sparkPos1 = Boxpos1;
                setcolor1(num1);
                obj1.tag = "one";

                Vector3 Boxpos2 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
                obj2 = Instantiate(spawnee[num2],Boxpos2,Quaternion.identity);
                sparkPos2 = Boxpos2;
                setcolor2(num2);
                obj2.tag = "two";

                Vector3 Boxpos3 = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
                obj3 = Instantiate(spawnee[num2],Boxpos3,Quaternion.identity);
                sparkPos3 = Boxpos3;
                setcolor3(num3);
                obj3.tag = "three";

                isSpawnon = false;
                boxone = false;
                boxtwo = false;
                boxthree = false;
            }
        }
        
    }
    void emitEffect(Color col , Vector3 pos){
        sparkle.GetComponent<ParticleSystem>().startColor = col;
        sparkle.transform.position = pos;
        sparkle.SetActive(true);
        StartCoroutine(stopSparckles());
    }

    IEnumerator stopSparckles(){
        yield return new WaitForSeconds(0.2f);
        sparkle.SetActive(false);
    }

    void setcolor1(int num){
        sparkColor1 = setcolor(num);
    }
    void setcolor2(int num){
        sparkColor2 = setcolor(num);
    }
    void setcolor3(int num){
        sparkColor3 = setcolor(num);
    }

    Color setcolor(int num){
        switch (num)
         {
            case 0:
                return new Color(0.9f, 0.6f, 0.09f, 1f);
                break;
            case 1:
                return new Color(0.0549f, 0.5529f, 0.9098f, 1f);
                break;
            case 2:
                return new Color(0.0549f, 0.9098f, 0.1098f, 1f);
                break;
            case 3:
                return new Color(0.7176f, 0.9686f, 0.0196f, 1f);
                break;
            case 4:
                return new Color(0.9686f, 0.3215f, 0.0196f, 1f);
                break;
            case 5:
                return new Color(0.9019f, 0.2627f, 0.2627f, 1f);
                break;
            case 6:
                return new Color(0.9098f,0.0549f, 0.1843f, 1f);
                break;
            case 7:
                return new Color(0.9294f,0.9411f, 0.1960f, 1f);
                break;
            default:
                return new Color(0.3f, 0.4f, 0.6f, 0.3f);
                break;
         }
    }
}
