using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{ 
    [SerializeField] private int _heartItem = 5, _coinShineItem = 6, _coinSpinItem = 10;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerExtrasTracker playerExtrasTracker;
    [Range(0.01f,10f)]
    [SerializeField] private float _speedItemDeath;

    public float SpeedItemDeath{ get => _speedItemDeath; set => _speedItemDeath = value; }
    public int HeartItem { get => _heartItem; set => _heartItem = value; }
    public int CoinShineItem { get => _coinShineItem; set => _coinShineItem = value; }
    public int CoinSpinItem { get => _coinSpinItem; set => _coinSpinItem = value; }

    private void Start()
    {
        HeartItem = 5;
        CoinSpinItem = 6;
        CoinShineItem = 10;
        player = GameObject.Find("Player");
        playerExtrasTracker = player.GetComponent<PlayerExtrasTracker>();
     }
    //Hice el conteo en forma descendente porque el item pide que muestre un 
    //debug de la cantidad pendiente de items por recoger.
    public void Heart()
    {
        HeartItem--;
        if (HeartItem == 0)
        {
            playerExtrasTracker.CanDoubleJump = true;
        }
    }
    public void CoinSpin()
    {
        CoinSpinItem--;
        if ((CoinSpinItem == 0) && (HeartItem == 0))
        {
            playerExtrasTracker.CanDash = true;
        }
    }
    public void CoinShine()
    {
        CoinShineItem--;
        if ((CoinShineItem == 0) && (HeartItem == 0) && (CoinSpinItem == 0))
        { 
            playerExtrasTracker.CanEnterBallMode = true;
            playerExtrasTracker.CanDropBombs = true;
        }
    }
}
