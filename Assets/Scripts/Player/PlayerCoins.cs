using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCoins : MonoBehaviour
{
    private int _coinCount;

    public event UnityAction<int> CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            _coinCount++;
            CoinCollected?.Invoke(_coinCount);
            coin.Die();
        }
    }
}
