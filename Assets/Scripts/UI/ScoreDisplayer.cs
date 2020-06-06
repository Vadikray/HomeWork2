using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private PlayerCoins _playerCoins;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _playerCoins.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _playerCoins.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected(int coinCount)
    {
        _score.text = coinCount.ToString();
    }
}
