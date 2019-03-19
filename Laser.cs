using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private float _laserSpeed = 10.0f;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
		

        //if moves out of view destroy
        if(transform.position.y >=6){
            Destroy(this.gameObject);
        }
	}
}
