using UnityEngine;

[CreateAssetMenu(menuName = "Random/Upgrade Random Pool/GameObject")]
public class GameObjectUpgradeRandomPool : UpgradeRandomPool<GameObject> {
    [SerializeField] GameObject HealthDrop;

    public override GameObject DefaultObject => HealthDrop;
}