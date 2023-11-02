using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Itens
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK
    }
    public class ItensManager : MonoBehaviour
    {
        public List<ItemSetup> itemSetups;
        public SaveManager saveManager;

        void Start()
        {
            Reset();
            LoadItensFromSave();
        }
        public void LoadItensFromSave()
        {
            AddByType(ItemType.COIN, saveManager.Setup.coins);
            AddByType(ItemType.LIFE_PACK, saveManager.Setup.health);
        }

        private void Reset()
        {
            foreach(var i in itemSetups)
            {
                i.soInt.value = 0;
            }
        }
        public ItemSetup GetItemByType(ItemType itemType)
        {
            return itemSetups.Find(i => i.itemType == itemType);
        }
        public void AddByType(ItemType itemType, int amount =1)
        {
            if (amount < 0) return;
            itemSetups.Find(i => i.itemType == itemType).soInt.value += amount;
        }
        public void RemoveByType(ItemType itemType, int amount = 1)
        {
            //if (amount < 0) return;
            var item = itemSetups.Find(i => i.itemType == itemType);
            item.soInt.value -= amount;
            if (item.soInt.value < 0) item.soInt.value = 0;
        }
    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOint soInt;
        public Sprite icon;
    }
}