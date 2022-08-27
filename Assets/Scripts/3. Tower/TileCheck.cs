using UnityEngine;

public class TileCheck : MonoBehaviour
{
    bool flag = true;
    public bool Flag { get { return flag; } set { flag = value; } }
    public void SetTileStatus(bool f)
    {
        Flag = f;
    }
    public Transform BuiltTower(GameObject builtPanel)
    {
        builtPanel.transform.position = transform.position;
        builtPanel.SetActive(true);
        return transform;
    }
    public Transform UpgradeAndSellTower(GameObject upgradePanel)
    {
        upgradePanel.transform.position = transform.position;
        upgradePanel.SetActive(true);
        return transform;
    }
}
