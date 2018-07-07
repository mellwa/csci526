using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Configuration;

public class Config {
    private static Config instance = new Config();
    private string configFilePath = Application.dataPath+"/config/GameConfiguration.json";
    private GameConfiguration gameConfiguration = null;
    private Config() {
        try{
            if(File.Exists(this.configFilePath)) {
                string dataJsonStr = File.ReadAllText(this.configFilePath);
                Debug.Log(dataJsonStr);
                this.gameConfiguration = JsonUtility.FromJson<GameConfiguration>(dataJsonStr);
            }
        }catch(Exception e) {
            Debug.Log(e.Message);
            throw e;
        }
    }

    public int getInitGold(int gameLevel) {
        int initGold = 300;
        switch(gameLevel){
            case 1:
                initGold = this.gameConfiguration.Settings.Beginner.Gold;
                break;
            case 2:
                initGold = this.gameConfiguration.Settings.Intermediate.Gold;
                break;
            case 3:
                initGold = this.gameConfiguration.Settings.Advanced.Gold;
                break;
            default:
                break;
        }
        return initGold;
    }

    public int getInitialHealth(int gameLevel) {
        int initHP = 1;
        switch (gameLevel)
        {
            case 1:
                initHP = this.gameConfiguration.Settings.Beginner.HP;
                break;
            case 2:
                initHP = this.gameConfiguration.Settings.Intermediate.HP;
                break;
            case 3:
                initHP = this.gameConfiguration.Settings.Advanced.HP;
                break;
            default:
                break;
        }
        return initHP;
    }

    public int getTowerPrice(int type) {
        int price = 100;
        switch(type) {
            case 1:
                price = this.gameConfiguration.TowerType.WaterTower.Price;
                break;
            case 2:
                price = this.gameConfiguration.TowerType.WoodTower.Price;
                break;
            case 3:
                price = this.gameConfiguration.TowerType.FireTower.Price;
                break;
            default:
                break;
        }
        return price;
    }

    public static Config getInstance() {

        return instance;
    }

}
