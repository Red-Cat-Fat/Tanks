using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public float value = 10f;
    public GameObject doors;
    private float _progress = 0f;
    private bool _capture = false;
    private bool _final = false;

    // Update is called once per frame
    void Update () {
        if (_capture)
        {
            _progress += Time.deltaTime;
        }
        if (value < _progress)
        {
            Final();
        }
	}

    public void Final()
    {
        Destroy(doors);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _capture = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _capture = false;
        }
    }
}
