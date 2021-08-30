using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _spawner;

    private Vector3 _ballStartPosition;
    private Vector3 _cameraStartPosition;

    private void Start()
    {
        _ballStartPosition = _ball.transform.position;
        _cameraStartPosition = Camera.main.transform.position;
        _spawner.SetActive(false);
        _ball.SetActive(false);
    }

    public void OnStartGame()
    {
        Time.timeScale = 1;
        _menu.SetActive(false);
        _gameMenu.SetActive(true);
        SetStartSettings();
        _spawner.SetActive(true);
        _ball.SetActive(true);
    }

    private void SetStartSettings()
    {
        _ball.transform.position = _ballStartPosition;
        Camera.main.transform.position = _cameraStartPosition;
    }
}
