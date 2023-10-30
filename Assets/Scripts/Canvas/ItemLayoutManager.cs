using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itens
{
    public class ItemLayoutManager : MonoBehaviour
    {
        public ItemLayout prefabLayout;
        public Transform conteiner;
        public ItensManager itensManager;
        public List<ItemLayout> itemLayouts;
        private void Start()
        {
            CreateItens();
        }
        private void CreateItens()
        {
            foreach(var setup in itensManager.itemSetups)
            {
                var item = Instantiate(prefabLayout, conteiner);
                item.Load(setup);
            }
        }
    }
}