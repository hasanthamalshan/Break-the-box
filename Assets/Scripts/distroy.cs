
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distroy : MonoBehaviour {

    public float cubeSize = 0.2f;
    public int cubesInRow = 10;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 20f;
    public float explosionUpward = 0f;

    // Use this for initialization
    void Start() {

        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
         Vector2 pos = Input.mousePosition;
         Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && (hitCollider.CompareTag ("Cube_red") || hitCollider.CompareTag ("Cube_green") || hitCollider.CompareTag ("Cube_blue") || hitCollider.CompareTag ("Cube_yellow"))) {
                explode();  
            }
        }
    }

    public void explode() {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++) {
            for (int y = 0; y < cubesInRow; y++) {
                    createPiece(x, y);
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders) {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y) {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * 0) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        var pieceRenderer = piece.GetComponent<Renderer>();
        if(gameObject.tag == "Cube_red"){
        pieceRenderer.material.SetColor("_Color", Color.red);
        }else if(gameObject.tag == "Cube_blue"){
        pieceRenderer.material.SetColor("_Color", Color.blue);
        }else if(gameObject.tag == "Cube_yellow"){
        pieceRenderer.material.SetColor("_Color", Color.yellow);
        }else if(gameObject.tag == "Cube_green"){
        pieceRenderer.material.SetColor("_Color", Color.green);
        }

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
      //piece.GetComponent<Rigidbody>().useGravity = false;
    }

}