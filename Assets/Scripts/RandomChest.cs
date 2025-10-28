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

    private GameObject selectedChest;
    private Vector3 spawnPosition = new Vector3(0, 0, -5);
    private GameObject currentChest;
    private GameObject currentLoot;

    private void Start()
    {
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

        //pick a random chest
        int randomChest = Random.Range(0, 5);
        switch (randomChest)
        {
            case 0: selectedChest = woodChest; break;
            case 1: selectedChest = bronzeChest; break;
            case 2: selectedChest = silverChest; break;
            case 3: selectedChest = goldChest; break;
            case 4: selectedChest = platinumChest; break;
        }

        //spawn chest
        Instantiate(selectedChest, Vector3.zero, Quaternion.identity);

        //roll for loot based on that chests table
        GameObject loot = GetLootForChest(randomChest);

        //spawn loot slightly above the chest
        Vector3 lootPosition = spawnPosition + new Vector3(0, 1, -5);
        Instantiate(loot, new Vector3(0,1,0), Quaternion.identity);

        Debug.Log($"Spawned {selectedChest.name} with loot: {loot.name}");
    }
    
    public GameObject GetLootForChest(int chestIndex)
    {
        
        float c = 0f;
        float u = 0f;
        float r = 0f;
        float e = 0f; 
        float l = 0f;

        switch (chestIndex)
        {
            case 0: 
                c = WoodChestCommon; 
                u = WoodChestUncommon; 
                r = WoodChestRare; 
                e = WoodChestEpic; 
                l = WoodChestLegendary; 
                break;
            case 1:
                c = BronzeChestCommon;
                u = BronzeChestUncommon;
                r = BronzeChestRare;
                e = BronzeChestEpic;
                l = BronzeChestLegendary;
                break;
            case 2:
                c = SilverChestCommon;
                u = SilverChestUncommon;
                r = SilverChestRare;
                e = SilverChestEpic;
                l = SilverChestLegendary;
                break;
            case 3:
                c = GoldChestCommon;
                u = GoldChestUncommon;
                r = GoldChestRare;
                e = GoldChestEpic;
                l = GoldChestLegendary;
                break;
            case 4:
                c = PlatinumChestCommon;
                u = PlatinumChestUncommon;
                r = PlatinumChestRare;
                e = PlatinumChestEpic;
                l = PlatinumChestLegendary;
                break;
            default: c = u = r = e = l = 0f; break;        
        }

        float total = c + u + r + e + l;

        //roll between 0 and total
        float roll = Random.Range(0f, total);

        if (roll <= c) return commonLoot;
        else if (roll <= c + u) return uncommonLoot;
        else if (roll <= c + u + r) return rareLoot;
        else if (roll <= c + u + r + e) return epicLoot;
        else return legendaryLoot;
    }


}
