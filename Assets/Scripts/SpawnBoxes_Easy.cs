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

    Vector3 sparkPos;

    public GameObject sparkle;
    Color sparkColor;
       
    void Start(){
        HealthBar.healthloss = 3f;
        sparkle.SetActive(false);
        Vector3 Boxpos = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
        obj = Instantiate(spawnee[2],Boxpos,Quaternion.identity);
        sparkColor = new Color(0.0549f, 0.9098f, 0.1098f, 1f);
        sparkPos = Boxpos;
        isSpawnon = false;
    }
    void Update()
    {   
        if (Input.GetMouseButtonDown(0) && !GameManager.isGameOver && !GameManager.isPaused) {
         int num = Random.Range(0,8);
         Vector2 pos = Input.mousePosition;
         Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null) {
                GameObject.Destroy(obj); 
                emitEffect();
                HealthBar.health = HealthBar.health + 50f; 
                GameManager.score++;
                isSpawnon = true; 
            }
            if(isSpawnon){
                Vector3 Boxpos = new Vector3(Random.Range(topLeft.position.x,bottomRight.position.x),Random.Range(bottomRight.position.y,topLeft.position.y),0); 
                obj = Instantiate(spawnee[num],Boxpos,Quaternion.identity);
                setcolor(num);
                sparkPos = Boxpos;
                isSpawnon = false;
            }
        }
        
    }

    void emitEffect(){
        sparkle.GetComponent<ParticleSystem>().startColor = sparkColor;
        sparkle.transform.position = sparkPos;
        sparkle.SetActive(true);
        StartCoroutine(stopSparckles());
    }

    IEnumerator stopSparckles(){
        yield return new WaitForSeconds(0.4f);
        sparkle.SetActive(false);
    }

    void setcolor(int num){
        switch (num)
         {
            case 0:
                sparkColor = new Color(0.9f, 0.6f, 0.09f, 1f);
                break;
            case 1:
                sparkColor = new Color(0.0549f, 0.5529f, 0.9098f, 1f);
                break;
            case 2:
                sparkColor = new Color(0.0549f, 0.9098f, 0.1098f, 1f);
                break;
            case 3:
                sparkColor = new Color(0.7176f, 0.9686f, 0.0196f, 1f);
                break;
            case 4:
                sparkColor = new Color(0.9686f, 0.3215f, 0.0196f, 1f);
                break;
            case 5:
                sparkColor = new Color(0.9019f, 0.2627f, 0.2627f, 1f);
                break;
            case 6:
                sparkColor = new Color(0.9098f,0.0549f, 0.1843f, 1f);
                break;
            case 7:
                sparkColor = new Color(0.9294f,0.9411f, 0.1960f, 1f);
                break;
            default:
                sparkColor = new Color(0.3f, 0.4f, 0.6f, 0.3f);
                break;
         }
    }
}
