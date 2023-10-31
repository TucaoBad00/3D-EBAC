using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Skin
{
    public class SkinItemBase : MonoBehaviour
    {
        public SkinType skinType;
        public float duration = 2;
        public SkinManager skinManager;
        public Player player;
        public string compareTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }
        public virtual void Collect()
        {
            var setup =  skinManager.GetSetupByType(skinType);
            player.ChangeTexture(setup,duration);
            HideObject();
        }
        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }
}
