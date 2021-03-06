﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour { 

    private GameObject laserPrefab;
    [SerializeField]
    private float fireRate = 0.25f;
    private float canFire = 0.0f;
    private float speed = 5.0f;


// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {

        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)){
           if(Time.time >canFire){
           Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                   canFire = Time.time + fireRate;
           }
            
        }
	}

    private void Movement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        if (transform.position.y>0){
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y > -4.2f){
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.y > -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }

    }
}
