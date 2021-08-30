using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameOverMenu;
    public void OnBack()
    {
        _gameOverMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
