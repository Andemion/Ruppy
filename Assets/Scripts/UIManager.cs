using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Score;
    public TMPro.TextMeshProUGUI Timer;

    private GameManager _gm;

    private void Awake()
    {
        _gm = GameManager.Instance;
    }

    private void Update()
    {
        Score.text = $"SCORE: {_gm.ScoreManager.Score}";
        Timer.text = $"TIME {TimeSpan.FromSeconds(_gm.TimeManager.Remaining):mm\\:ss}";
    }
}
