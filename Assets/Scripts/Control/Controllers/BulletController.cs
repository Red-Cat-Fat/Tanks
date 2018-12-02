using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public float Speed = 1f;
    public float LifeTime = 2f;

    private float _lifeTimer = 0;
    private Rigidbody _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnEnable()
    {
        _rigidbody.velocity = transform.forward * Speed;
        _lifeTimer = LifeTime;
    }

    private void Update()
    {
        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer <= 0)
        {
            GameManager.Instance.poolManager.Despawn(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.poolManager.Despawn(gameObject);
    }
}
