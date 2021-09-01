using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _gemeOverDelay;
    [SerializeField] private Vector3 _reboundVector;

    public UnityAction GameOver;
    public UnityAction<int> CoinCatched;
    public UnityAction<int> BonusChargesChanged;

    private int _currentBonusCharges = 0;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            if (_currentBonusCharges == 0)
            {
                _coroutine = StartCoroutine(SetGameOver(_gemeOverDelay));
            }
            else
            {
                obstacle.Disable();
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
            coin.Disable();
        }

        if (other.TryGetComponent(out Bonus bonus))
        {
            _currentBonusCharges += bonus.BonusCharges;
            BonusChargesChanged?.Invoke(_currentBonusCharges);
            CoinCatched?.Invoke(bonus.ScoreValue);
            bonus.Disable();
        }
    }

    private IEnumerator SetGameOver(float gameOverDelay)
    {
        BallMover mover = gameObject.GetComponent<BallMover>();
        mover.enabled = false;
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(_reboundVector, ForceMode.Impulse);
        yield return new WaitForSeconds(gameOverDelay);
        mover.enabled = true;
        GameOver?.Invoke();
    }
}
