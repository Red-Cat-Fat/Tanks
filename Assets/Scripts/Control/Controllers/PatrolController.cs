﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour, IController {
    private bool _canFire = false;
    private IMove _moveToPoint;
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
        _moveToPoint = GetComponent<IMove>();
        _currentPatrolWayTarget = patrolWay.GetCurrentPoint();
        _moveToPoint.MoveTo(_currentPatrolWayTarget.gameObject);
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
            _moveToPoint.LookAt(_target);
        }
        else
        {
            StopFire();
            if (_currentPatrolWayTarget == null)
            {
                _currentPatrolWayTarget = patrolWay.GetPointByIndex(0);
            }
            _moveToPoint.MoveTo(_currentPatrolWayTarget.transform.position);
            if (Vector3.Distance(transform.position, _currentPatrolWayTarget.transform.position) < distance)
            {
                _currentPatrolWayTarget = patrolWay.GetNextPoint();
                _moveToPoint.LookAt(_currentPatrolWayTarget.gameObject);
            }
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
}
