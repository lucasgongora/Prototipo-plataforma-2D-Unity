using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    private ItemManager itemManager;
    private int val1 = 5, val2 = 6, val3 = 10;

    private void Start()
    {
        itemManager = GameObject.Find("ItemsManager").GetComponent<ItemManager>();
    }
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Heart         ");
        val1 = itemManager.HeartItem;
        GUILayout.TextField(val1.ToString(), 10);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("CoinSpin     ");
        val2 = itemManager.CoinSpinItem;
        GUILayout.TextField(val2.ToString(), 10);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("CoinShine   ");
        val3 = itemManager.CoinShineItem;
        GUILayout.TextField(val3.ToString(), 10);
        GUILayout.EndHorizontal();
    }
}
                                                