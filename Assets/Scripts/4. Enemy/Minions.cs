using System.Collections.Generic;

public class Minions : AEnemy
{
    public class EnemyConverter : JsonConverter<List<EnemyJs>> { }
    public class EnemyJs
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
    public override void SetEnemy(string id)
    {
        //import data from json here
        EnemyConverter ec = new EnemyConverter();
        ec.setCurrentDir(@"\EnemyStats.json");
        List<EnemyJs> ar = ec.getObjectFromJSON();
        foreach (EnemyJs a in ar)
            if (a.id == id)
            {
                HP = a.hp;
                //RunSpeed = a.speed;
                DamageToCastle = a.damage;
                Reward = a.killReward;
                //Size = a.height;
            }
    }
    public override void Start()
    {
        SetEnemy("enemy_01_1");
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    //public override void SetEnemy(string id)
    //{
    //    throw new System.NotImplementedException();
    //}
}
