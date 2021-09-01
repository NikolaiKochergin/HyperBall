using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _scoreValue;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private MeshRenderer _meshRenderer;

    public int ScoreValue => _scoreValue;

    public void Disable()
    {
        float time = _particleSystem.main.startLifetimeMultiplier;
        _meshRenderer.enabled = false;
        _particleSystem.Play();
        StartCoroutine(DisableBy(time));        
    }

    private IEnumerator DisableBy(float time)
    {
        yield return new WaitForSeconds(time);
        _meshRenderer.enabled = true;
        gameObject.SetActive(false);
    }
}
