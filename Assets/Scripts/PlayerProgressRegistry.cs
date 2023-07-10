using UnityEngine;
using UnityEngine.UI;

public class PlayerProgressRegistry : MonoBehaviour
{
    public int currentLevel = 1;
    public int keys = 0;
    public int coins = 0;

    public float attackStat = 3.5f;
    public float speedStat = 1.0f;
    public float rangeStat = 1.25f;
    public float slashSpeedStat = 7.5f;
    public float luckStat = 0f;

    public bool easterEggSeen = false;
    public bool finishedGame = false;
    public bool showPlayerStats = false;

    public bool hasBrimstone = false;
    public bool hasTrisword = false;
    public bool hasTrickword = false;
    public bool hasJar = false;
    public bool hasCharm = false;
    public bool hasPwdSword = false;

    public const string HaveYouSeenHimKey = "HaveYouSeenHim?";
    public const string FinishedDemoKey = "FinishedDemo?";
    public const string VisiblePlayerStatsKey = "VisiblePlayerStatsForIsaacPlayers";
    public const string CurrentLevelKey = "Current Level";
    public const string KeysOnHandKey = "Keys on Hand";
    public const string CollectedCoinsKey = "Collected Coins";
    public const string AttackStatKey = "Attack Stat on Run";
    public const string SpeedStatKey = "Speed Stat on Run";
    public const string RangeStatKey = "Range Stat on Run";
    public const string SlashSpeedStatKey = "Slash Speed Stat on Run";
    public const string LuckStatKey = "Luck Stat on Run";
    public const string HasBrimstoneKey = "HasBrimstone";
    public const string HasTriswordKey = "HasTrisword";
    public const string HasTrickwordKey = "HasTrickword";
    public const string HasJarKey = "HasJar";
    public const string HasCharmKey = "HasCharm";
    public const string HasPwdSwordKey = "HasPwdSword";
    public Button toggleStatsButton;

    public void Start()
    {   
        // Configurar el estado inicial del botón según showPlayerStats
        if(toggleStatsButton != null)
        {
            toggleStatsButton.GetComponentInChildren<Text>().text = showPlayerStats ? "Disable Stats" : "Enable Stats";
        }
        

        // Agregar un listener al botón para activar/desactivar los stats del jugador
        toggleStatsButton.onClick.AddListener(TogglePlayerStats);

        LoadPlayerData();
        LoadPlayerRunData();
        LoadPlayerStatsData();
    }
    private void TogglePlayerStats()
    {
        showPlayerStats = !showPlayerStats;
        Debug.Log("Player Stats: " + (showPlayerStats ? "Enabled" : "Disabled"));

        // Guardar el valor actual de showPlayerStats en PlayerPrefs
        PlayerPrefs.SetInt("VisiblePlayerStatsForIsaacPlayers", showPlayerStats ? 1 : 0);
        PlayerPrefs.Save();

        // Actualizar el texto del botón según el nuevo estado de showPlayerStats
        toggleStatsButton.GetComponentInChildren<Text>().text = showPlayerStats ? "Disable Stats" : "Enable Stats";
    }

    public void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey(HaveYouSeenHimKey))
        {
            easterEggSeen = PlayerPrefs.GetInt(HaveYouSeenHimKey) != 0;
        }

        if (PlayerPrefs.HasKey(FinishedDemoKey))
        {
            finishedGame = PlayerPrefs.GetInt(FinishedDemoKey) != 0;
        }

        if (PlayerPrefs.HasKey(VisiblePlayerStatsKey))
        {
            showPlayerStats = PlayerPrefs.GetInt(VisiblePlayerStatsKey) != 0;
        }

        if (PlayerPrefs.HasKey("VisiblePlayerStatsForIsaacPlayers"))
        {
            int showStatsValue = PlayerPrefs.GetInt("VisiblePlayerStatsForIsaacPlayers");
            showPlayerStats = showStatsValue != 0;
        }
    }

    public void LoadPlayerRunData()
    {
        if (PlayerPrefs.HasKey(CurrentLevelKey))
        {
            currentLevel = PlayerPrefs.GetInt(CurrentLevelKey);
        }

        if (PlayerPrefs.HasKey(KeysOnHandKey))
        {
            keys = PlayerPrefs.GetInt(KeysOnHandKey);
        }

        if (PlayerPrefs.HasKey(CollectedCoinsKey))
        {
            coins = PlayerPrefs.GetInt(CollectedCoinsKey);
        }

        if (PlayerPrefs.HasKey(HasBrimstoneKey))
        {
            finishedGame = PlayerPrefs.GetInt(HasBrimstoneKey) != 0;
        }

        if (PlayerPrefs.HasKey(HasCharmKey))
        {
            finishedGame = PlayerPrefs.GetInt(HasCharmKey) != 0;
        }

        if (PlayerPrefs.HasKey(HasJarKey))
        {
            finishedGame = PlayerPrefs.GetInt(HasJarKey) != 0;
        }

        if (PlayerPrefs.HasKey(HasPwdSwordKey))
        {
            finishedGame = PlayerPrefs.GetInt(HasPwdSwordKey) != 0;
        }

        if (PlayerPrefs.HasKey(HasTrickwordKey))
        {
            finishedGame = PlayerPrefs.GetInt(HasTrickwordKey) != 0;
        }

        if (PlayerPrefs.HasKey(HasTriswordKey))
        {
            finishedGame = PlayerPrefs.GetInt(HasTriswordKey) != 0;
        }
    }

    public void LoadPlayerStatsData()
    {
        if (PlayerPrefs.HasKey(AttackStatKey))
        {
            attackStat = PlayerPrefs.GetFloat(AttackStatKey);
        }

        if (PlayerPrefs.HasKey(SpeedStatKey))
        {
            speedStat = PlayerPrefs.GetFloat(SpeedStatKey);
        }

        if (PlayerPrefs.HasKey(RangeStatKey))
        {
            rangeStat = PlayerPrefs.GetFloat(RangeStatKey);
        }

        if (PlayerPrefs.HasKey(SlashSpeedStatKey))
        {
            slashSpeedStat = PlayerPrefs.GetFloat(SlashSpeedStatKey);
        }

        if (PlayerPrefs.HasKey(LuckStatKey))
        {
            luckStat = PlayerPrefs.GetFloat(LuckStatKey);
        }
    }

    public void SavePlayerProgress()
    {
        PlayerPrefs.SetInt(HaveYouSeenHimKey, easterEggSeen ? 1 : 0);
        PlayerPrefs.SetInt(FinishedDemoKey, finishedGame ? 1 : 0);
        PlayerPrefs.SetInt(VisiblePlayerStatsKey, showPlayerStats ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SavePlayerRunProgress()
    {
        PlayerPrefs.SetInt(CurrentLevelKey, currentLevel);
        PlayerPrefs.SetInt(KeysOnHandKey, keys);
        PlayerPrefs.SetInt(CollectedCoinsKey, coins);
        PlayerPrefs.SetInt(HasBrimstoneKey, hasBrimstone ? 1 : 0);
        PlayerPrefs.SetInt(HasCharmKey, hasCharm ? 1 : 0);
        PlayerPrefs.SetInt(HasJarKey, hasJar ? 1 : 0);
        PlayerPrefs.SetInt(HasPwdSwordKey, hasPwdSword ? 1 : 0);
        PlayerPrefs.SetInt(HasTriswordKey, hasTrisword ? 1 : 0);
        PlayerPrefs.SetInt(HasTrickwordKey, hasTrickword ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SavePlayerStats()
    {
        PlayerPrefs.SetFloat(AttackStatKey, attackStat);
        PlayerPrefs.SetFloat(SpeedStatKey, speedStat);
        PlayerPrefs.SetFloat(RangeStatKey, rangeStat);
        PlayerPrefs.SetFloat(SlashSpeedStatKey, slashSpeedStat);
        PlayerPrefs.SetFloat(LuckStatKey, luckStat);
        PlayerPrefs.Save();
    }

    public void NewGame()
    {
        currentLevel = 1;
        keys = 0;
        coins = 0;

        attackStat = 3.5f;
        speedStat = 1.0f;
        rangeStat = 1.25f;
        slashSpeedStat = 7.5f;
        luckStat = 0f;

        hasBrimstone = false;
        hasTrisword = false;
        hasTrickword = false;
        hasJar = false;
        hasCharm = false;
        hasPwdSword = false;

        SavePlayerProgress();
        SavePlayerRunProgress();
        SavePlayerStats();

    }
}
