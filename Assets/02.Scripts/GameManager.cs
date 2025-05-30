﻿using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private UIManager uiManager;
    private Character player;
    private int gold = 0;
    public List<ItemData> items;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            player = new Character("르탄", 1, 0, 10, "과제 중인 르탄이", 10, 20, 100, 5, items);

            uiManager = UIManager.Instance;
            if (uiManager != null)
            {
                uiManager.GetMainMenu().SetCharacterData(player);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Character GetPlayer()
    {
        return player;
    }

    public int GetGold()
    {
        return gold;
    }
}
