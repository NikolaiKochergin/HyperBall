using UnityEngine;

public class Obstacle4Fix1 : MonoBehaviour
{
    [SerializeField] private GameObject _secondHalfOfObstacle;
    private void OnEnable()
    {
        _secondHalfOfObstacle.SetActive(true);
    }
    private void OnDisable()
    {
        _secondHalfOfObstacle.SetActive(false);
    }
}
