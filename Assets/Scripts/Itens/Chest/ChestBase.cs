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
    public void Start()
    {
        HideNotification();
    }
    private void OpenChest()
    {
        if (chestOpen) return;
        animator.SetTrigger(triggerOpen);
        chestOpen = true;
        Invoke("ShowItem", 1f);
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
