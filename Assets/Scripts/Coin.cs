using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int _scoreValue;

    public int ScoreValue => _scoreValue;
}
