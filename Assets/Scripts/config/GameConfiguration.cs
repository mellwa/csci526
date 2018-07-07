using System;
namespace Configuration
{
    [System.Serializable]
    public class GameConfiguration
    {
        public TowerType TowerType = new TowerType();
        public ArmyType ArmyType = new ArmyType();
        public Settings Settings = new Settings();
    }

    [System.Serializable]
    public class TowerType
    {
        public FireTower FireTower = new FireTower();
        public WoodTower WoodTower = new WoodTower();
        public WaterTower WaterTower = new WaterTower();
        public DarkTower DarkTower = new DarkTower();
        public LightTower LightTower = new LightTower();

    }

    [System.Serializable]
    public class TowerConfig
    {
        public string Tower_Type = "";
        public int Price = 0;
        public int Damage = 0;
        public int Range = 0;
        public int FireRate = 0;
        public float FireBug = 0;
        public float WoodBug = 0;
        public float WaterBug = 0;

    }

    [System.Serializable]
    public class FireTower : TowerConfig { }

    [System.Serializable]
    public class WoodTower : TowerConfig { }

    [System.Serializable]
    public class WaterTower : TowerConfig { }

    [System.Serializable]
    public class DarkTower : TowerConfig { }

    [System.Serializable]
    public class LightTower : TowerConfig { }

    [System.Serializable]
    public class ArmyType
    {
        public FireBug FireBug = new FireBug();
        public WoodBug WoodBug = new WoodBug();
        public WaterlBug WaterlBug = new WaterlBug();
        public Bee Bee = new Bee();
    }

    [System.Serializable]
    public class BugConfig
    {
        public string Type = "";
        public int Gold_Earned = 10;
        public int Speed = 1;
        public int Health = 100;
    }

    [System.Serializable]
    public class FireBug : BugConfig { }

    [System.Serializable]
    public class WoodBug : BugConfig { }

    [System.Serializable]
    public class WaterlBug : BugConfig { }

    [System.Serializable]
    public class Bee : BugConfig { }

    [System.Serializable]
    public class Settings
    {
        public Beginner Beginner = new Beginner();
        public Intermediate Intermediate = new Intermediate();
        public Advanced Advanced = new Advanced();
    }

    [System.Serializable]
    public class LevelConfig{
        public string Level = "beginner";
        public int Gold = 1000;
        public int HP = 1;
        public int Waves = 5;
    }

    [System.Serializable]
    public class Beginner:LevelConfig { }

    [System.Serializable]
    public class Intermediate:LevelConfig { }

    [System.Serializable]
    public class Advanced:LevelConfig { }
}
