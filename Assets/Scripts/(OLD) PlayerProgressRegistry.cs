using UnityEngine;

public class OldPlayerProgressRegistry : MonoBehaviour
{
    int EasterEggCheck = 0;
    int FinishedDemoCheck = 0;
    int PlayerStatCheck = 0;

    void Start()
    {
        int currentLevel = 1;
        int keys = 0;
        int coins = 0;

        float attackStat = 3.5f;
        float speedStat = 1.0f;
        float rangeStat = 1.25f;
        float slashSpeedStat = 2.0f;
        float luckStat = 0f;

        bool easterEggSeen = false;
        bool finishedGame = false;
        bool showPlayerStats = false;

        LoadPlayerData(easterEggSeen, finishedGame, showPlayerStats);
        LoadPlayerRunData(currentLevel, keys, coins);
        LoadPlayerStatsData(attackStat, speedStat, rangeStat, slashSpeedStat, luckStat);
    }

    public void LoadPlayerData(bool easterEggSeen, bool finishedGame, bool showPlayerStats)
    {
        if (PlayerPrefs.HasKey("HaveYouSeenHim?"))
        {
            EasterEggCheck = PlayerPrefs.GetInt("HaveYouSeenHim?");
            easterEggSeen = EasterEggCheck != 0;
        }

        if (PlayerPrefs.HasKey("FinishedDemo?"))
        {
            FinishedDemoCheck = PlayerPrefs.GetInt("FinishedDemo?");
            finishedGame = FinishedDemoCheck != 0;
        }

        if (PlayerPrefs.HasKey("VisiblePlayerStatsForIsaacPlayers"))
        {
            PlayerStatCheck = PlayerPrefs.GetInt("VisiblePlayerStatsForIsaacPlayers");
            showPlayerStats = PlayerStatCheck != 0;
        }
    }

    public void LoadPlayerRunData(int currentLevel, int keys, int coins)
    {   
        if (PlayerPrefs.HasKey("Current Level"))
        {
            currentLevel = PlayerPrefs.GetInt("Current Level");
        }
 
        if (PlayerPrefs.HasKey("Keys on Hand"))
        {
            keys = PlayerPrefs.GetInt("Keys on Hand");
        }

        if (PlayerPrefs.HasKey("Collected Coins"))
        {
            coins = PlayerPrefs.GetInt("Collected Coins");
        }
    }

    public void LoadPlayerStatsData(float attackStat, float speedStat, float rangeStat, float slashSpeedStat, float luckStat)
    {
        if (PlayerPrefs.HasKey("Attack Stat on Run"))
        {
            attackStat = PlayerPrefs.GetFloat("Attack Stat on Run");
        }

        if (PlayerPrefs.HasKey("Speed Stat on Run"))
        {
            speedStat = PlayerPrefs.GetFloat("Speed Stat on Run");
        }

        if (PlayerPrefs.HasKey("Range Stat on Run"))
        {
            rangeStat = PlayerPrefs.GetFloat("Range Stat on Run");
        }

        if (PlayerPrefs.HasKey("Slash Speed Stat on Run"))
        {
            slashSpeedStat = PlayerPrefs.GetFloat("Slash Speed Stat on Run");
        }

        if (PlayerPrefs.HasKey("Luck Stat on Run"))
        {
            luckStat = PlayerPrefs.GetFloat("Luck Stat on Run");
        }
    }

    public void SavePlayerProgress(bool easterEggSeen, bool finishedGame, bool showPlayerStats)
    {
        PlayerPrefs.SetInt("HaveYouSeenHim?", easterEggSeen ? 1 : 0);
        PlayerPrefs.SetInt("FinishedDemo?", finishedGame ? 1 : 0);
        PlayerPrefs.SetInt("VisiblePlayerStatsForIsaacPlayers", showPlayerStats ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void SavePlayerRunProgress(int currentLevel, int keys, int coins)
    {
        PlayerPrefs.SetInt("Current Level", currentLevel);
        PlayerPrefs.SetInt("Keys on Hand", keys);
        PlayerPrefs.SetInt("Collected Coins", coins);
    }

    public void SavePlayerStats(float attackStat, float speedStat, float rangeStat, float slashSpeedStat, float luckStat)
    {
        PlayerPrefs.SetFloat("Attack Stat on Run", attackStat);
        PlayerPrefs.SetFloat("Speed Stat on Run", speedStat);
        PlayerPrefs.SetFloat("Range Stat on Run", rangeStat);
        PlayerPrefs.SetFloat("Slash Speed Stat on Run", slashSpeedStat);
        PlayerPrefs.SetFloat("Luck Stat on Run", luckStat);

        PlayerPrefs.Save();
    }
}
