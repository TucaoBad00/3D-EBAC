using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Itens
{
    public class ItemColletableBase : MonoBehaviour
    {
        public ItemType itemType;
        public string compareTag = "Player";
        public ItensManager itensManager;
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }
        protected virtual void Collect()
        {
            OnCollect();
            Destroy(gameObject);
        }
        protected virtual void OnCollect()
        {
            itensManager.AddByType(itemType);
        }
    }
}
