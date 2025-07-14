using UnityEngine;
using Fusion;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameLauncher gameLauncher;

    void Start()
    {
        // ゲーム開始時にスコアを初期化
        scoreText.text = "Score: 0";
        // GameLauncherのイベントを購読
        gameLauncher.OnPlayerJoined += OnPlayerJoined;
    }
    void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        // プレイヤーが参加したときの処理
        Debug.Log($"Player {player} has joined the game.");
        // ここでスコアの初期化やUIの更新などを行うことができます
    }
}
