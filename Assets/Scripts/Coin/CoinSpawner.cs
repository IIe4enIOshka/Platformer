using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _waitForSeconds;
    [SerializeField] private int _numberCoins;

    private int _currentPoint = 0;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_waitForSeconds);

        for (int i = 0; i < _numberCoins; i++)
        {
            Instantiate(_template, _spawnPoints[_currentPoint]);

            _currentPoint++;

            if (_currentPoint >= _spawnPoints.Length)
            {
                _currentPoint = 0;
            }

            yield return waitForSeconds;
        }
    }
}
