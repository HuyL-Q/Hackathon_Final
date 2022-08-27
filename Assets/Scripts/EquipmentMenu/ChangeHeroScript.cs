using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHeroScript : MonoBehaviour
{
    public Transform changeHeroPanel;
    public GameObject changeHeroPrefab;
    public GameObject ChampionImage;
    public static GameObject ChampionImageStatic;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Champion c in GameControllerE.championList)
        {
            GameObject button = Instantiate(changeHeroPrefab,changeHeroPanel);
            button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/Champion/" + c.ID);
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(delegate { changeHero(c.ID); });
        }
        ChampionImageStatic = ChampionImage;
    }
    public static void changeHero(string choosenId)
    {
        ChampionImageStatic.GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/Champion/" + choosenId);
        foreach(Champion c in GameControllerE.championList)
        {
            if (c.ID.Equals(choosenId))
            {
                AttributeController.ChangeAttack(c.Damage.ToString());
                AttributeController.ChangeAttackSpeed(c.AttackSpeed.ToString());
                AttributeController.ChangeRange(c.Range.ToString());
                AttributeController.ChangeHealth(c.Health.ToString());
            }
        }

        GameControllerE.DisableChangeHeroMenu();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
