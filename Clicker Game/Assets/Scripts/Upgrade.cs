using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    public int Level { get; set; }
    public int CurrentCost { get; set; }

    public Sprite icon;

    public int cost = 50;
    [Range(1f, 2f)] public float costIncreaseMultiplier = 1f;

    public UpgradeType upgradeType = UpgradeType.Click;
    public int upgradeValue = 1;
}

public enum UpgradeType
{
    Click,
    Auto
}