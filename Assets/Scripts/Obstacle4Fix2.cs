using UnityEngine;

public class Obstacle4Fix2 : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (Transform item in this.gameObject.transform)
            item.gameObject.SetActive(true);
    }
}
