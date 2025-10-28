using UnityEngine;
using UnityEngine.UI;

public class RandomChest : MonoBehaviour
{
    [Header("Chest Type")]
    [SerializeField] private float WoodChest;
    [SerializeField] private float BronzeChest;
    [SerializeField] private float SilverChest;
    [SerializeField] private float GoldChest;
    [SerializeField] private float PlatinumChest; 

    [Header("Wood Chest Loot")]
    [SerializeField] private float WoodChestCommon;
    [SerializeField] private float WoodChestUncommon;
    [SerializeField] private float WoodChestRare;
    [SerializeField] private float WoodChestEpic;
    [SerializeField] private float WoodChestLegendary;

    [Header("Bronze Chest Loot")]
    [SerializeField] private float BronzeChestCommon;
    [SerializeField] private float BronzeChestUncommon;
    [SerializeField] private float BronzeChestRare;
    [SerializeField] private float BronzeChestEpic;
    [SerializeField] private float BronzeChestLegendary;

    [Header("Silver Chest Loot")]
    [SerializeField] private float SilverChestCommon;
    [SerializeField] private float SilverChestUncommon;
    [SerializeField] private float SilverChestRare;
    [SerializeField] private float SilverChestEpic;
    [SerializeField] private float SilverChestLegendary;

    [Header("Gold Chest Loot")]
    [SerializeField] private float GoldChestCommon;
    [SerializeField] private float GoldChestUncommon;
    [SerializeField] private float GoldChestRare;
    [SerializeField] private float GoldChestEpic;
    [SerializeField] private float GoldChestLegendary;

    [Header("Platinum Chest Loot")]
    [SerializeField] private float PlatinumChestCommon;
    [SerializeField] private float PlatinumChestUncommon;
    [SerializeField] private float PlatinumChestRare;
    [SerializeField] private float PlatinumChestEpic;
    [SerializeField] private float PlatinumChestLegendary;

    [Header("Chest Prefabs")]
    [SerializeField] private GameObject woodChest;
    [SerializeField] private GameObject bronzeChest;
    [SerializeField] private GameObject silverChest;
    [SerializeField] private GameObject goldChest;
    [SerializeField] private GameObject platinumChest;

    [Header("Loot Prefabs")]
    [SerializeField] private GameObject commonLoot;
    [SerializeField] private GameObject uncommonLoot;
    [SerializeField] private GameObject rareLoot;
    [SerializeField] private GameObject epicLoot;
    [SerializeField] private GameObject legendaryLoot;

    [Header("Claim Reward Button")]
    [SerializeField] private Button claimRewardButton;

    [Header("Spawn Parent")]
    [SerializeField] private Transform objectSim;

    private GameObject selectedChest;

    private GameObject currentChest;
    private GameObject currentLoot;

    private void Start()
    {
        //show cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //hook up the button
        if (claimRewardButton != null)
        {
            claimRewardButton.onClick.AddListener(GenerateRandomChest);
        }
    }

    private void Update()
    {
        // space bar also triggers the same as button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateRandomChest();
        }
    }

    private void GenerateRandomChest()
    {
        //clear old chest + loot before spawning new ones
        if (currentChest != null) Destroy(currentChest);
        if (currentLoot != null) Destroy(currentLoot);

        //select chest using weight
        float totalChestWeight = WoodChest + BronzeChest + SilverChest + GoldChest + PlatinumChest;
        float chestRoll = Random.Range(0f, totalChestWeight);
        int chestIndex = 0;

        if (chestRoll <= WoodChest) chestIndex = 0;
        else if (chestRoll <= WoodChest + BronzeChest) chestIndex = 1;
        else if (chestRoll <= WoodChest + BronzeChest + SilverChest) chestIndex = 2;
        else if (chestRoll <= WoodChest + BronzeChest + SilverChest + GoldChest) chestIndex = 3;
        else chestIndex = 4;

        //assign selected chest
        switch (chestIndex)
        {
            case 0: selectedChest = woodChest; break;
            case 1: selectedChest = bronzeChest; break;
            case 2: selectedChest = silverChest; break;
            case 3: selectedChest = goldChest; break;
            case 4: selectedChest = platinumChest; break;
        }

        //spawn chest
        currentChest = Instantiate(selectedChest, objectSim.position, selectedChest.transform.rotation);

        GameObject loot = GetLootForChest(chestIndex);
        Vector3 lootPosition = objectSim.position + new Vector3(0,2,0);
        currentLoot = Instantiate(loot, lootPosition, loot.transform.rotation);

        currentChest.transform.parent = objectSim;
        currentLoot.transform.parent = objectSim;


        //console 
        Debug.Log($"You opened {selectedChest.name}, and won {loot.name}!");
    }
    
    public GameObject GetLootForChest(int chestIndex)
    {
        //create arrays for weights and loot
        float[] weights = new float[5];
        GameObject[] lootPrefabs = new GameObject[] {commonLoot, uncommonLoot, rareLoot, epicLoot, legendaryLoot};

        //assign weights to chest types
        switch (chestIndex)
        {
            case 0: weights = new float[] { WoodChestCommon, WoodChestUncommon, WoodChestRare, WoodChestEpic, WoodChestLegendary }; break;
            case 1: weights = new float[] { BronzeChestCommon, BronzeChestUncommon, BronzeChestRare, BronzeChestEpic, BronzeChestLegendary }; break;
            case 2: weights = new float[] { SilverChestCommon, SilverChestUncommon, SilverChestRare, SilverChestEpic, SilverChestLegendary }; break;
            case 3: weights = new float[] { GoldChestCommon, GoldChestUncommon, GoldChestRare, GoldChestEpic, GoldChestLegendary }; break;
            case 4: weights = new float[] { PlatinumChestCommon, PlatinumChestUncommon, PlatinumChestRare, PlatinumChestEpic, PlatinumChestLegendary }; break;
            default: weights = new float[] { 0, 0, 0, 0, 0 }; break;
        }

        //random selection
        float total = 0f;
        foreach (float w in weights) total += w;
        float roll = Random.Range(0f, total);

        float cumulative = 0f;
        for (int i = 0; i < weights.Length; i++)
        {
            cumulative += weights[i];
            if (roll <= cumulative)
                return lootPrefabs[i];
        }

        return commonLoot;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
