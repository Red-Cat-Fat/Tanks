using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public LifeParameters playersLifeParameters;
    public Image slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //slider.value = playersLifeParameters.healthPoints / playersLifeParameters.maxHealthPoints;
        slider.fillAmount = playersLifeParameters.healthPoints / playersLifeParameters.maxHealthPoints;
    }
}
