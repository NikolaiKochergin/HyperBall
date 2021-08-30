using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    public UnityAction GameOver;
    public UnityAction<int> CoinCatched;
    public UnityAction<int> BonusChargesChanged;

    private int _currentBonusCharges = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            if (_currentBonusCharges == 0)
            {
                GameOver?.Invoke();
            }
            else
            {
                collision.gameObject.SetActive(false);
                _currentBonusCharges--;
                BonusChargesChanged?.Invoke(_currentBonusCharges);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            CoinCatched?.Invoke(coin.ScoreValue);
            coin.gameObject.SetActive(false);
        }

        if (other.TryGetComponent(out Bonus bonus))
        {
            _currentBonusCharges += bonus.BonusCharges;
            BonusChargesChanged?.Invoke(_currentBonusCharges);
            CoinCatched?.Invoke(bonus.ScoreValue);
            bonus.gameObject.SetActive(false);
        }
    }
}
