using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bullet;
    public bool fire = true;
    public float timeReload = 1f;
    public GameObject pointGeneratorBullet;

    private PoolManager poolManager;
    private float lastFire = 0;
    private Team _team = Team.Computer;

    public void Start()
    {
        //poolManager = GameManager.Instance.poolManager;

        if (pointGeneratorBullet == null)
        {
            pointGeneratorBullet = gameObject;
        }

        UnitData unitData = gameObject.GetComponent<UnitData>();
        if (unitData != null)
        {
            _team = unitData.team;
        }
        else
        {
            Debug.LogError("UnitData is null in " + gameObject.name);
        }

    }

    private void Update()
    {
        lastFire += Time.deltaTime;
        GameObject target = FindTarget();
        if (target != null && lastFire > timeReload)
        {
            GameObject newBullet = Instantiate(bullet, pointGeneratorBullet.transform.position, pointGeneratorBullet.transform.rotation);//poolManager.Spawn(bullet, pointGeneratorBullet.transform.position, pointGeneratorBullet.transform.rotation);
            Debug.Log("Bullet " + newBullet.name + " generation by " + gameObject.name);

            MoveToPoint moveToPointBullet = newBullet.GetComponent<MoveToPoint>();
            if (moveToPointBullet != null)
            {
                moveToPointBullet.MoveTo(pointGeneratorBullet.transform.position, target);

                DealingDamage dealingDamageBullet = newBullet.GetComponent<DealingDamage>();
                dealingDamageBullet.SetTeam(_team);
                lastFire = 0;
            }
        }
    }
    private GameObject FindTarget()
    {
        int layerMask = 1 << 2;
        layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(pointGeneratorBullet.transform.position, pointGeneratorBullet.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(pointGeneratorBullet.transform.position, pointGeneratorBullet.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            GameObject target = hit.collider.gameObject;
            UnitData targetUnitData = target.GetComponent<UnitData>();
            if (targetUnitData != null)
            {
                if (targetUnitData.team != _team)
                {
                    return target;
                }
            }
        }
        else
        {
            Debug.DrawRay(pointGeneratorBullet.transform.position, pointGeneratorBullet.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
        return null;
    }
}
