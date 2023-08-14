using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Globals globals;
    public SceneData scene;
    public List<SceneData> sceneList;
    public GameData() 
    {
        globals = new Globals();
        scene = new SceneData();
        sceneList = new List<SceneData>();
        sceneList.Add(scene);
    }

    public SceneData GetSceneData(string sceneName)
    {
        foreach (SceneData sceneData in sceneList)
        {
            if(sceneData.name == sceneName)
            {
                return sceneData;
            } 
        }
        return null;
    }

    public void SetSceneData(SceneData info)
    {
        sceneList.RemoveAll(sceneInfo => sceneInfo.name == info.name);
        sceneList.Add(info);

        if(info.name != "MainMenu")
        {
            globals.lastSceneName = info.name;
        }
    }
    public int GetPercentageComplete() 
    {
        // figure out how many coins we've collected
        int totalCollected = 0;
        foreach (bool collected in scene.coinsCollected.Values) 
        {
            if (collected) 
            {
                totalCollected++;
            }
        }

        // ensure we don't divide by 0 when calculating the percentage
        int percentageCompleted = -1;
        if (scene.coinsCollected.Count != 0) 
        {
            percentageCompleted = (totalCollected * 100 / scene.coinsCollected.Count);
        }
        return percentageCompleted;
    }

    public void CreateNewSceneData()
    {
        scene = new SceneData();
        //sceneList.Add(scene);
    }

    [System.Serializable]
    public class Globals
    {
        public long lastUpdated;
        public int deathCount;
        public float healthAmount;

        public string lastSceneName;

        public List<Item> itemList;
        public Globals()
        {
            this.deathCount = 0;
            healthAmount = 100;
            itemList = new List<Item>();
            lastSceneName = "SampleScene";
        }
    }

    [System.Serializable]
    public class SceneData
    {
        public string name;
        public Vector3 playerPosition;
        public SerializableDictionary<string, bool> coinsCollected;
        public SerializableDictionary<string, bool> itemsCollected;
        public SerializableDictionary<string, bool> testCollected;

        public SceneData()
        {
            this.name = "DefaultSceneName";
            playerPosition = Vector3.zero;
            coinsCollected = new SerializableDictionary<string, bool>();
            itemsCollected = new SerializableDictionary<string, bool>();
             testCollected = new SerializableDictionary<string, bool>();
        }
    }
}

