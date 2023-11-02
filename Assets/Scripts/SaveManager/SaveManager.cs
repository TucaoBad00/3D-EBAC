using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Core.Sigleton;
using System;
public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    private SaveSetup _saveSetup;

    public Health health;
    public Itens.ItensManager itensManager;

    public int lastLevel;

    public Action<SaveSetup> FileLoaded;

    public SaveSetup Setup
    {
        get { return _saveSetup; }
    }

    private string _path = Application.streamingAssetsPath + "/save.txt";
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

       
    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "Arthur";
    }

    private void Start()
    {
        Invoke(nameof(Load), .1f);
    }

    #region SAVE
    [NaughtyAttributes.Button]
    private void Save()
    {
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }
    public void SaveItens()
    {
        _saveSetup.coins = (int)itensManager.GetItemByType(Itens.ItemType.COIN).soInt.value;
        _saveSetup.health = (int)itensManager.GetItemByType(Itens.ItemType.LIFE_PACK).soInt.value;
        Save();
    }
    public void SaveName(string text)
    {
        _saveSetup.playerName = text;
        Save();
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveItens();
    }
    #endregion

    

    private void SaveFile(string json)
    {
        Debug.Log(_path);
        File.WriteAllText(_path, json);
    }
    [NaughtyAttributes.Button]
    private void Load()
    {
        string fileLoaded = "";

        if (File.Exists(_path))
        {
            fileLoaded = File.ReadAllText(_path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
            lastLevel = _saveSetup.lastLevel;
        }
        else
        {
            CreateNewSave();
            Save();
        }
        FileLoaded.Invoke(_saveSetup);

    }


    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }
}

[System.Serializable]
public class SaveSetup
{
    public int coins;
    public int health;


    public int lastLevel;
    public string playerName;
    public string qualquer;
}
