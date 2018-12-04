using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {
    [Serializable]
    public class PoolPrespawnData
    {
        public GameObject Prefab;
        public int Count;
    }

    public PoolManager poolManager;
    public PoolPrespawnData[] Prespawns;
    public AIManager aiManager;
    public GameObject player;
    public GameObject theBase;
    public Text message;

    private LifeParameters playersLife;
    private LifeParameters baseLife;
    public static GameManager Instance { get; private set; }
    public const float sizeGameGrid = 5f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < Prespawns.Length; ++i)
        {
            var prespawn = Prespawns[i];
            poolManager.Prespawn(prespawn.Prefab, prespawn.Count);
        }
        playersLife = player.GetComponent<LifeParameters>();
        baseLife = theBase.GetComponent<LifeParameters>();
    }

    public void ShowMessage(string messages)
    {
        message.text = messages;
        message.gameObject.SetActive(true);
        Invoke("CloseMessage", 3);
    }

    private void CloseMessage()
    {
        message.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (!playersLife.isLife())
        {
            Time.timeScale = 0.01f;
            message.text = "Вас убили!";
            message.gameObject.SetActive(true);
        }
        if (!baseLife.isLife())
        {
            Time.timeScale = 0.01f;
            message.gameObject.SetActive(true);
            message.text = "Вы выйграли!!!";
        }
	}
}
