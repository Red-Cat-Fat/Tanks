using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float timeReload = 1f;
    public GameObject bullet;
    public GameObject pointGeneratorBullet;

    private float lastFire = 0;
    private IController controller;
    private Team _team = Team.Computer;

    public void Start()
    {
        if (pointGeneratorBullet == null)
        {
            pointGeneratorBullet = gameObject;
        }
        controller = gameObject.GetComponent<IController>();
        UnitData unitData = gameObject.GetComponent<UnitData>();
        _team = unitData.team;
    }

    private void Update()
    {
        lastFire += Time.deltaTime;
        if (lastFire > timeReload)
        {
            if (controller.CanFire)
            {
                Fire();
            }
        }
    }

    public void Fire()
    {
        GameObject newBullet = GameManager.Instance.poolManager.Spawn(bullet, pointGeneratorBullet.transform.position, pointGeneratorBullet.transform.rotation);
        DealingDamage dealingDamageBullet = newBullet.GetComponent<DealingDamage>();
        dealingDamageBullet.SetTeam(_team);
        lastFire = 0;
    }

    
}
