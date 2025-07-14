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
        // �Q�[���J�n���ɃX�R�A��������
        scoreText.text = "Score: 0";
        // GameLauncher�̃C�x���g���w��
        gameLauncher.OnPlayerJoined += OnPlayerJoined;
    }
    void OnPlayerJoined(NetworkRunner runner, PlayerRef player,NetworkObject spawnedObject)
    {
        // �v���C���[���Q�������Ƃ��̏���
        Debug.Log($"Player {player} has joined the game.");
        // �����ŃX�R�A�̏�������UI�̍X�V�Ȃǂ��s�����Ƃ��ł��܂�

        if (spawnedObject != null)
        {
            Debug.Log($"Add an Action: {spawnedObject.Id} for Player {player}");
            spawnedObject.GetComponent<PlayerAvatar>().OnItemCollectedAction += (Object, item) =>
            {
                // �A�C�e�����擾�����Ƃ��̏���
                Debug.Log($"{Object.NickName.Value} collected an item: {item.Object.Id}");
                // �X�R�A���X�V
                score++;
                scoreText.text = $"Score: {score}";
            };
        }
    }
}
