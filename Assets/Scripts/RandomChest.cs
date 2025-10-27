using UnityEngine;

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

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
