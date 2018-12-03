using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingDamage : MonoBehaviour {
    public float damagSize = 0;
    public TypeAttack typeAttack = TypeAttack.NormalType;
    private Team _team;
    private Damage damage;
	// Use this for initialization
	void Start () {
        damage = new Damage(damagSize, typeAttack);
	}

    public void OnCollisionEnter(Collision collision)
    {
        LifeParameters lifeParameters = collision.gameObject.GetComponent<LifeParameters>();
        if (lifeParameters != null)
        {
            Brick targetBrick = collision.gameObject.GetComponent<Brick>();
            if (targetBrick != null)
            {
                lifeParameters.SetDamage(damage);
            }
            UnitData targetUnitData = collision.gameObject.GetComponent<UnitData>();
            if (targetUnitData != null)
            {
                if (targetUnitData.team != _team)
                {
                    lifeParameters.SetDamage(damage);

                    GameManager.Instance.poolManager.Despawn(gameObject);
                }
            }
        }
    }

    public void SetTeam(Team team)
    {
        _team = team;
    }
}
