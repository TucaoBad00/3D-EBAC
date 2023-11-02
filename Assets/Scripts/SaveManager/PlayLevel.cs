using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayLevel : MonoBehaviour
{
    public SaveManager saveManager;
    public TextMeshProUGUI uiTextName;

    private void Start()
    {
        saveManager.FileLoaded += OnLoad;
    }
    public void OnLoad(SaveSetup setup)
    {
        uiTextName.text = "Play" + (setup.lastLevel + 1);
    }

    private void OnDestroy()
    {
        saveManager.FileLoaded -= OnLoad;
    }
}
