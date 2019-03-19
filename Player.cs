using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool canTrippleShot = false;

    [SerializeField] 
    private GameObject _laserPrefab;

    [SerializeField] 
    private GameObject _tripleLaser;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    private float speed = 5.0f;


// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {

        Movement();

        if (Input.GetButton("Fire1"))
        {
            Shoot();
            
        }
	}

    private void Shoot(){

    //if triplelaser collected equal true
    //shoot tree
    //if else shoot one
        if (Time.time > _canFire) 
        {
         if(canTrippleShot == true){
            
            Instantiate(_tripleLaser, transform.position, Quaternion.identity);
         }   
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.01f, 0), Quaternion.identity);
            _canFire = Time.time + _fireRate;
        }
    }
    
    private void Movement(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        //if player on y is greater than 0
        //set player position Y to be 0
        if (transform.position.y > 0){
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f){
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //if player on x is greater than 9,5
        //set player position x to be -9,5

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }

    }
}
