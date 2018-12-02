using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody _rigidbody;
    public float moveSpeed = 10;

    private Vector3 vectorMove = Vector3.zero;
    // Use this for initialization
    void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        vectorMove = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        Move();

    }
    public void Move()
    {
        vectorMove.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        vectorMove.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        if (Vector3.Angle(Vector3.forward, vectorMove) > 1f || Vector3.Angle(Vector3.forward, vectorMove) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, vectorMove, moveSpeed, 0f);
            _rigidbody.transform.rotation = Quaternion.LookRotation(direct);
        }

        _rigidbody.transform.position = (vectorMove + _rigidbody.transform.position);
    }
}
