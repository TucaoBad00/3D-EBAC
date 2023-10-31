using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Skin
{
    public enum SkinType
    {
        DEFAULT,
        SPEED,
        SPIKES
    }
    public class SkinManager : MonoBehaviour
    {
        public List<SkinSetup> clouthSetups;

        public SkinSetup GetSetupByType(SkinType clothType)
        {
            return clouthSetups.Find(i => i.clothType == clothType);
        }

    }
    [System.Serializable]
    public class SkinSetup
    {
        public SkinType clothType;
        public Texture2D texture;
    }
}