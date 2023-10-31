using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

namespace Skin
{
    public class SkinChanger : MonoBehaviour
    {
        public SkinnedMeshRenderer mesh;

        public Texture2D texture;
        public string shaderIdName = "_EmissionMap";
        private Texture defaultTexture;
        private void Awake()
        {
            defaultTexture = mesh.sharedMaterials[0].GetTexture(shaderIdName);
        }


        public void ChangeTexture(SkinSetup setup)
        {
            mesh.sharedMaterials[0].SetTexture(shaderIdName, setup.texture);
        }
        public void ResetTexture()
        {
            mesh.sharedMaterials[0].SetTexture(shaderIdName, defaultTexture);
        }
    }
}
