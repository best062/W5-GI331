using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankUIManager : MonoBehaviour
{
    public GameObject rankDataPrefab;
    public Transform rankPanel;

    public List<PlayerData> playerDatas = new List<PlayerData>();
    public List<GameObject> createdPlayerDatas = new List<GameObject>();

    private void Start()
    {
        CreateRankData();
    }
    public void CreateRankData()
    {
        for (int i = 0;i<playerDatas.Count;i++)
        {
            GameObject rankObj = Instantiate(rankDataPrefab,rankPanel);
            RankData rankData = rankObj.GetComponent<RankData>();
            rankData.playerData = new PlayerData(playerDatas[i].rankNumber,
                playerDatas[i].playerName,
                playerDatas[i].playerScore,
                playerDatas[i].profileSprite);
            
            rankData.UpdateData();
            createdPlayerDatas.Add(rankObj);
        }
    }

    private void SortRankData()
    {
        List<PlayerData> sortRankPlayer =new List<PlayerData>();
        sortRankPlayer = playerDatas.OrderByDescending(
            data => data.playerScore).ToList();

        for(int i = 0; i < sortRankPlayer.Count; i++)
        {
            PlayerData changedRankNum = sortRankPlayer[i];
            changedRankNum.rankNumber = i + 1;

            sortRankPlayer[i] = changedRankNum;
        }

        playerDatas = sortRankPlayer;

    }

    private void ClearRankData()
    {
        foreach(GameObject createdData in createdPlayerDatas)
        {
            Destroy(createdData);
        }
        createdPlayerDatas.Clear();
    }

    [ContextMenu("Reload")]
    public void ReloadRankData()
    {
        ClearRankData();
        SortRankData();
        CreateRankData();
    }
}