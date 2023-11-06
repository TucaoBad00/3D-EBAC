using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBase : MonoBehaviour,IInteractable
{
    public Animator animator;
    public string triggerOpen = "Open";
    public GameObject notification;
    public ChestItemBase chestItem;
    public bool chestOpen = false;
    public ParticleSystem particle;
    public new AudioSource audio;
    public void Start()
    {
        HideNotification();
    }
    private void OpenChest()
    {
        if (chestOpen) return;
        animator.SetTrigger(triggerOpen);
        particle.Play();
        audio.Play();
        Invoke("ShowItem", 1f);
        chestOpen = true;
    }
    private void ShowItem()
    {
        chestItem.ShowItem();
        CollectItem();
    }
    public void CollectItem()
    {
        chestItem.Collect();
    }

    public void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if(p != null)
        {
            ShowNotification();
        }
        SaveManager.Instance.SaveItens();
    }
    private void OnTriggerExit(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if(p!= null)
        {
            HideNotification();
        }
    }
    private void ShowNotification()
    {
        notification.SetActive(true);
    }
    private void HideNotification()
    {
        notification.SetActive(false);
    }

    public void IInteract()
    {
        OpenChest();
    }

}
