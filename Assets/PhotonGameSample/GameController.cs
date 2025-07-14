using UnityEngine;
using Fusion;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameLauncher gameLauncher;

    void Start()
    {
        // �Q�[���J�n���ɃX�R�A��������
        scoreText.text = "Score: 0";
        // GameLauncher�̃C�x���g���w��
        gameLauncher.OnPlayerJoined += OnPlayerJoined;
    }
    void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        // �v���C���[���Q�������Ƃ��̏���
        Debug.Log($"Player {player} has joined the game.");
        // �����ŃX�R�A�̏�������UI�̍X�V�Ȃǂ��s�����Ƃ��ł��܂�
    }
}
