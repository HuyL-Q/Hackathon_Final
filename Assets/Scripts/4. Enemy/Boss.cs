using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AEnemy
{

    public class EnemyConverter : JsonConverter<List<BossJs>> { }
    public class BossJs
    {
        public string id;
        public int level;
        public int hp;
        public float speed;
        public int damage;
        public int killReward;
        public int width;
        public int height;
    }
    //public override void SetEnemy(string id)
    //{
    //    //import data from json here
    //    EnemyConverter ec = new EnemyConverter();
    //    ec.setCurrentDir(@"\Assets\JSON\EnemyStats.json");
    //    List<BossJs> ar = ec.getObjectFromJSON();
    //    foreach (BossJs a in ar)
    //        if (a.id == id)
    //        {
    //            Hp = a.hp;
    //            RunSpeed = a.speed;
    //            DamageToCastle = a.damage;
    //            Reward = a.killReward;
    //            Size = a.height;
    //        }
    //}
    public override void Start()
    {
        base.Start();
    }

    public override void SetEnemy(string id)
    {
        throw new System.NotImplementedException();
    }
}