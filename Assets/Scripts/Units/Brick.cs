using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    private LifeParameters _lifeParameters;
	// Use this for initialization
	void Start () {
        _lifeParameters = GetComponent<LifeParameters>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!_lifeParameters.isLife())
        {
            Destroy(gameObject);
        }
	}
}
