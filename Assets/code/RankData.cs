using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct PlayerData
{
    public string playerName;
    public int rankNumber;
    public int playerScore;
    public Sprite profileSprite;

    public PlayerData(int rankNumber, string playerName
        ,int playerScore, Sprite profileSprite)
    {
        this.rankNumber = rankNumber;
        this.playerName = playerName;
        this.playerScore = playerScore;
        this.profileSprite = profileSprite;
    }
}

public class RankData : MonoBehaviour
{
    public PlayerData playerData;

    [SerializeField] private RawImage profileImg;
    [SerializeField] private Sprite defaultProfileSprite;
    [SerializeField] private TMP_Text rankText;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private TMP_Text scoreText;

    [ContextMenu("Update Data")]
    public void UpdateData()
    {
        profileImg.texture = playerData.profileSprite != null
            ? playerData.profileSprite.texture : defaultProfileSprite.texture;

        rankText.text = playerData.rankNumber.ToString();
        playerNameText.text = playerData.playerName;
        scoreText.text = playerData.playerScore.ToString("n0");
    }
}