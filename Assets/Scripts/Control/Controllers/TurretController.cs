using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour, IController
{
    public float SpeedRotation = 45f;
    public float FrequencyRotation = 3f;
    public LayerMask findTargetInLayer;

    private float _lifeTime = 0;
    private bool _canFire = false;
    private Gun[] _guns;
    private Rigidbody _rigidbody;
    private Vector3 position;
    private Team _team = Team.Computer;


    public bool CanFire
    {
        get
        {
            return _canFire;
        }
    }

    public void Start()
    {
        _guns = GetComponents<Gun>();
        _rigidbody = GetComponent<Rigidbody>();
        position = _rigidbody.transform.position;
        UnitData unitData = gameObject.GetComponent<UnitData>();
        _team = unitData.team;
    }

    public void Update()
    {
        _lifeTime += Time.deltaTime;
        FindTarget();
        if (!_canFire)
        {
            Move();
        }
    }
    public GameObject FindTarget()
    {
        RaycastHit hit;
        for (int i = 0; i < _guns.Length; i++)
        {
            if (Physics.Raycast(_guns[i].pointGeneratorBullet.transform.position, _guns[i].pointGeneratorBullet.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, findTargetInLayer))
            {
                Debug.DrawRay(_guns[i].pointGeneratorBullet.transform.position, _guns[i].pointGeneratorBullet.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                GameObject target = hit.collider.gameObject;
                UnitData targetUnitData = target.GetComponent<UnitData>();
                if (targetUnitData != null)
                {
                    if (targetUnitData.team != _team)
                    {
                        StartFire();
                        return target;
                    }
                }
                else
                {
                    StopFire();
                }
            }
            else
            {
                StopFire();
                Debug.DrawRay(_guns[i].pointGeneratorBullet.transform.position, _guns[i].pointGeneratorBullet.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            }
        }
        return null;
    }

    public void Move()
    {
        if (_lifeTime > FrequencyRotation)
        {
            _rigidbody.transform.Rotate(0, SpeedRotation, 0);
            _rigidbody.position = position;
            _lifeTime -= FrequencyRotation;
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
