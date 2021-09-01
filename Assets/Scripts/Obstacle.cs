using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private MeshRenderer _meshRenderer;
    private Collider _collider;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    public void Disable()
    {
        float time = _particleSystem.main.startLifetimeMultiplier;
        _meshRenderer.enabled = false;
        _collider.enabled = false;
        _particleSystem.Play();
        StartCoroutine(DisableBy(time));
    }

    private IEnumerator DisableBy(float time)
    {
        yield return new WaitForSeconds(time);
        _meshRenderer.enabled = true;
        _collider.enabled = true;
        gameObject.SetActive(false);
    }
}
