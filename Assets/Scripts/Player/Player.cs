using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coin;

    public event UnityAction<int> CoinChanged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            AddCoin();
            Destroy(coin.gameObject);
        }
    }

    private void Start()
    {
        CoinChanged?.Invoke(_coin);
    }

    public void AddCoin()
    {
        _coin++;
        CoinChanged?.Invoke(_coin);
    }

    public void ApplyDamage()
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
