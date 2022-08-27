using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    GameObject tower;
    SpriteRenderer rangeSprite;
    private void Awake()
    {
        rangeSprite = gameObject.GetComponent<SpriteRenderer>();
        rangeSprite.enabled = false;
    }
    void Start()
    {
        tower = gameObject.transform.parent.gameObject;
    }
    public void Select(bool status)
    {
        rangeSprite.enabled = status;
    }
    void Update()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            transform.localScale = 1.85f * tower.GetComponent<ATower>().Range * Vector3.one;
        }
    }
}
