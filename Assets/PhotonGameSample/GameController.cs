using UnityEngine;
using Fusion;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameLauncher gameLauncher;

    private int score = 0;

    void Start()
    {
        // ゲーム開始時にスコアを初期化
        scoreText.text = "Score: 0";
        // GameLauncherのイベントを購読
        gameLauncher.OnPlayerJoined += OnPlayerJoined;
    }
    void OnPlayerJoined(NetworkRunner runner, PlayerRef player,NetworkObject spawnedObject)
    {
        // プレイヤーが参加したときの処理
        Debug.Log($"Player {player} has joined the game.");
        // ここでスコアの初期化やUIの更新などを行うことができます

        if (spawnedObject != null)
        {
            Debug.Log($"Add an Action: {spawnedObject.Id} for Player {player}");
            spawnedObject.GetComponent<PlayerAvatar>().OnItemCollectedAction += (Object, item) =>
            {
                // アイテムを取得したときの処理
                Debug.Log($"{Object.NickName.Value} collected an item: {item.Object.Id}");
                // スコアを更新
                score++;
                scoreText.text = $"Score: {score}";
            };
        }
    }
}
