using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    private float _powerUpSpeed = 0.3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * _powerUpSpeed);


	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);
        //handle to the component
        if(other.tag == "Player"){
           //access the player
           Player player = other.GetComponent<Player>();

           if(player != null){
              //turn tripleshot true
              player.canTrippleShot = true; //must be public
              //destroy powerup
              Destroy(this.gameObject);

           }
           

        }
        




    }
}
