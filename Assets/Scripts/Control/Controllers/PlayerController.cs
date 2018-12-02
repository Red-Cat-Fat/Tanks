using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController {
    private Rigidbody _rigidbody;
    public float moveSpeed = 10;

    private Vector3 vectorMove = Vector3.zero;
    private bool _canFire = false;

    public bool CanFire
    {
        get
        {
            return _canFire;
        }
    }
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

        MoveToPoint moveToPoint = GetComponent<MoveToPoint>();
        moveToPoint.MoveTo(vectorMove + _rigidbody.transform.position);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartFire();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopFire();
        }
        //_rigidbody.transform.position = (vectorMove + _rigidbody.transform.position);
    }

    public void StartFire()
    {
        _canFire = true;
    }

    public void StopFire()
    {
        _canFire = false;
    }
}
