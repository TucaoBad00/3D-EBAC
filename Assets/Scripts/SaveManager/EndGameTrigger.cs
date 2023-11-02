using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGameTrigger : MonoBehaviour
{
    public List<GameObject> endGameObjects;
    public SaveManager saveManager;
    private bool _endGame;

    public int currentLevel = 1;

    private void Awake()
    {
        endGameObjects.ForEach(i => i.SetActive(false));

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(!_endGame && other.CompareTag("Player"))
        {
            ShowEndGame();
        }
        _endGame = true;

    }

    private void ShowEndGame()
    {
        endGameObjects.ForEach(i => i.SetActive(true));

        foreach(var i in endGameObjects)
        {
            i.SetActive(true);
            i.transform.DOScale(0,.2f).SetEase(Ease.OutBack).From();
            saveManager.SaveLastLevel(currentLevel);
        }
    }
}
