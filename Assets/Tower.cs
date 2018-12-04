using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour {
    public float value = 10f;
    public GameObject doors;
    public Image slider;
    private float _progress = 0f;
    private bool _capture = false;
    private Text text;

    public void Start()
    {
        text = slider.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update () {
        if (_capture)
        {
            _progress += Time.deltaTime;
            slider.fillAmount = _progress / value;
            text.text = Convert.ToString((int)(slider.fillAmount * 100)) + "%";//знаю, что так нельзя, просто нет времени
        }
        if (_progress != 0)
        {
            slider.gameObject.SetActive(true);
        }
        if (value < _progress)
        {
            Final();
        }
    }

    public void Final()
    {
        slider.gameObject.SetActive(false);
        GameManager.Instance.ShowMessage("Дверь открылась!");
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
