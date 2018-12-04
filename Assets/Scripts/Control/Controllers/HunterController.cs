using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour, IController
{
    public GameObject target;
    public float distance = 3f;

    private bool _canFire = true;
    private IMove _moveToPoint;
    public bool CanFire
    {
        get
        {
            return _canFire;
        }
    }

    public void Start()
    {
        _moveToPoint = GetComponent<IMove>();
    }

    public void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > distance)
        {
            _moveToPoint.MoveTo(target);
        }
        _moveToPoint.LookAt(target);
    }

    public void StartFire()
    {
        _canFire = true;
    }

    public void StopFire()
    {
        //no
    }
}
