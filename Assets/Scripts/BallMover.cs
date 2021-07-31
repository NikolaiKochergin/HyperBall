using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _deflectionSpeed;

    public float Speed => _speed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(0, 0, _speed);

        if (Application.platform == RuntimePlatform.Android)
        {
            Touch touch = Input.GetTouch(0);
            _rigidbody.velocity = new Vector3(touch.deltaPosition.x * _deflectionSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);
        }

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButton(0))
            {
                float screenMousePositionX = Mathf.Clamp(Input.mousePosition.x, 0, Camera.main.scaledPixelWidth);

                Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(screenMousePositionX, 1, 1.7f));

                float deltaPositionX = worldMousePosition.x - transform.position.x;

                _rigidbody.velocity = new Vector3(deltaPositionX * _deflectionSpeed, 0, _rigidbody.velocity.z);
            }
        }
    }
}
