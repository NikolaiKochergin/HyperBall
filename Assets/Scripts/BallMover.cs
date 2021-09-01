using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CollisionHandler))]

public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _deflectionSpeed;
    [SerializeField] private float _bonusSpeed;
    [SerializeField] [Range(0, 1)] private float _inputFieldShare;

    public float CarrentSpeed => _carrentSpeed;

    private CollisionHandler _handler;
    private Rigidbody _rigidbody;
    private float _carrentSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _handler = GetComponent<CollisionHandler>();
        _carrentSpeed = _speed;
    }

    private void OnEnable()
    {
        _handler.BonusChargesChanged += OnBonusChargesChanged;
    }

    private void OnDisable()
    {
        _handler.BonusChargesChanged -= OnBonusChargesChanged;
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(0, 0, _carrentSpeed);

        if (Input.GetMouseButton(0))
        {
            float mousePositionX = Mathf.Clamp(Input.mousePosition.x - (Camera.main.scaledPixelWidth * 0.5f), -Camera.main.scaledPixelWidth * _inputFieldShare * 0.5f, Camera.main.scaledPixelWidth * _inputFieldShare * 0.5f);

            float targetPositionX = mousePositionX / (Camera.main.scaledPixelWidth * _inputFieldShare);

            //float targetPositionX = Mathf.Clamp((Input.mousePosition.x / Camera.main.scaledPixelWidth) - 0.5f, -0.5f, 0.5f);

            float deltaPositionX = targetPositionX - transform.position.x;

            _rigidbody.velocity = new Vector3(deltaPositionX * _deflectionSpeed, 0, _rigidbody.velocity.z);
        }
    }

    private void OnBonusChargesChanged(int bonusCharges)
    {
        if (bonusCharges == 0)
            _carrentSpeed = _speed;
        else
            _carrentSpeed = _bonusSpeed;
    }
}
