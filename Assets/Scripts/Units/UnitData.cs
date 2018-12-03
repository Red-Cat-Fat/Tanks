using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    PlayerOne,
    PlayerTwo,
    Computer
}
public class UnitData : MonoBehaviour {
    public Team team;
    public IModification modification;
    private LifeParameters lifeParameters;

    public void Start()
    {
        lifeParameters = GetComponent<LifeParameters>();
        if (lifeParameters == null)
        {
            Debug.LogError("LifeParameters in " + gameObject.name + " is null");
        }
    }

    public void Update()
    {
        UpdateModification();
        UpdateLifeParameters();
    }

    public void UpdateAll()
    {
        UpdateModification();
        UpdateLifeParameters();
    }

    public void UpdateModification()
    {
        if (modification != null)
        {
            modification.UpdateMode();
        }
    }

    public void UpdateLifeParameters()
    {
        if (!lifeParameters.isLife()) {
            if (lifeParameters != null)
            {
                if (gameObject.GetComponent<PoolObject>() != null)
                {
                    GameManager.Instance.poolManager.Despawn(gameObject);
                }
                else
                {
                    if (gameObject.GetComponent<PlayerController>() == null)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
