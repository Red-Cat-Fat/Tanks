using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour, IController {
    private bool _canFire = false;
    private MoveToPoint _moveToPoint;
    private PatrolWayPoint _currentPatrolWayTarget;

    public PatrolWay patrolWay;
    public bool CanFire
    {
        get
        {
            return _canFire;
        }
    }
    
    void Start()
    {
        _moveToPoint = GetComponent<MoveToPoint>();
        _currentPatrolWayTarget = patrolWay.GetCurrentPoint();
    }
    
    void Update()
    {
        Move();
        FindTarget();
    }

    public GameObject FindTarget()
    {
        return null;
    }

    public void Move()
    {
        if(_currentPatrolWayTarget == null)
        {
            _currentPatrolWayTarget = patrolWay.GetPointByIndex(0);
        }
        _moveToPoint.MoveTo(_currentPatrolWayTarget.transform.position);
    }

    public void StartFire()
    {
        _canFire = true;
    }

    public void StopFire()
    {
        _canFire = false;
    }


    public void ConnectToPatrolWayPoint(GameObject go)
    {
        PatrolWayPoint collosionPoint = go.GetComponent<PatrolWayPoint>();
        if (collosionPoint != null)
        {
            _currentPatrolWayTarget = patrolWay.IsTrueWay(collosionPoint);
            _moveToPoint.MoveTo(_currentPatrolWayTarget.transform.position);
        }
    }
}
