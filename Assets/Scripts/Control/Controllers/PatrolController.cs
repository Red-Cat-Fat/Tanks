using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour, IController {
    private bool _canFire = false;
    private MoveToPoint _moveToPoint;
    private PatrolWayPoint _currentPatrolWayTarget;
    private GameObject _target;
    private Eyesight _eyesight;

    public float distance = 5f;
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
        _eyesight = GetComponent<Eyesight>();
    }
    
    void Update()
    {
        Move();
        _target = FindTarget();
        if (_target != null)
        {
            StartFire();
        }
    }

    public GameObject FindTarget()
    {
        List<GameObject> targets = _eyesight.GetVisibleUnits();
        if (targets!=null && targets.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                Debug.DrawLine(transform.position, targets[i].transform.position, Color.yellow);
                if (targets[i].GetComponent<PlayerController>() != null)
                {
                    return targets[i];
                }
            }
        }
        return null;
    }

    public void Move()
    {
        if (_target != null)
        {
            _moveToPoint.MoveTo(_target.transform.position);
        }
        else
        {
            StopFire();
            if (_currentPatrolWayTarget == null)
            {
                _currentPatrolWayTarget = patrolWay.GetPointByIndex(0);
            }
            _moveToPoint.MoveTo(_currentPatrolWayTarget.transform.position);
        }
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
