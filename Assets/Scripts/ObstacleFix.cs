using UnityEngine;

public class ObstacleFix : MonoBehaviour
{
    [SerializeField] private GameObject _childeObstacle;
    private void OnEnable()
    {
        _childeObstacle.SetActive(true);
    }
}
