using UnityEngine;

public class PlatformGenerator : ObjectPool
{
    [SerializeField] private GameObject _platformTemplate;

    private Vector3 _nextSpawnPosition;

    private void Start()
    {
        _nextSpawnPosition = transform.position;

        Initialize(_platformTemplate);

        for (int i = 0; i < Capacity; i++)
        {
            SetPlatform(Pool[i]);
        }
    }

    private void Update()
    {
        CangePlatformPosition();
    }

    private void CangePlatformPosition()
    {
        Vector3 changePositionPoint = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0));

        foreach (var item in Pool)
        {
            if (item.transform.position.z < changePositionPoint.z - item.transform.localScale.z / 2f)
            {
                SetPlatform(item);
            }
        }
    }
    private void SetPlatform(GameObject platform)
    {
        platform.transform.position = _nextSpawnPosition;
        _nextSpawnPosition.z += platform.transform.localScale.z;
    }
}
