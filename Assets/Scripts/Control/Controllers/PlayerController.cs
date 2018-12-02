using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody _rigidbody;
    public float speed = 10;
	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal")* speed;
        float vertical = Input.GetAxis("Vertical")* speed;

        _rigidbody.transform.position = new Vector3(transform.position.x + horizontal, transform.position.y, transform.position.z + vertical);
    }
}
