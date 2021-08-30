using UnityEngine;
using TMPro;

public class RecordsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ScoreViewer _viewer;

    private void OnEnable()
    {
        _text.SetText("Scores: " + _viewer.Scores);
    }
}
