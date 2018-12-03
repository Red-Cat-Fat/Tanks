using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    public List<GameObject> units = new List<GameObject>();

    public void AddUnit(GameObject unit)
    {
        units.Add(unit);
    }
}
