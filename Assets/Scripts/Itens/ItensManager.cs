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

        void Start()
        {
            Reset();
        }

        private void Reset()
        {
            foreach(var i in itemSetups)
            {
                i.soInt.Value = 0;
            }
        }
        public ItemSetup GetItemByType(ItemType itemType)
        {
            return itemSetups.Find(i => i.itemType == itemType);
        }
        public void AddByType(ItemType itemType, int amount =1)
        {
            if (amount < 0) return;
            itemSetups.Find(i => i.itemType == itemType).soInt.Value += amount;
        }
        public void RemoveByType(ItemType itemType, int amount = 1)
        {
            //if (amount < 0) return;
            var item = itemSetups.Find(i => i.itemType == itemType);
            item.soInt.Value -= amount;
            if (item.soInt.Value < 0) item.soInt.Value = 0;
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