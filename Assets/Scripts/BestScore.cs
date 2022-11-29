using Save;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BestScore: MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        SetBestScoreOnTextMesh();
    }

    private void SetBestScoreOnTextMesh()
    {
        var data = BinarySaveSystem.Load();
        if (data.LastScore < data.BestScore)
        {
            _scoreText.text += data.BestScore;
            return;
        }
        _scoreText.text += data.LastScore;
        data.BestScore = data.LastScore;
        BinarySaveSystem.Save(data);
    }
    
}