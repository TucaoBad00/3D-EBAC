using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Itens
{
    public class ItemLayout : MonoBehaviour
    {
        private ItemSetup _currentSetup;

        public Image uiIcon;
        public TextMeshProUGUI uiValue;
        public void Load(ItemSetup setup)
        {
            _currentSetup = setup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _currentSetup.icon;
        }
        private void Update()
        {
            uiValue.text = _currentSetup.soInt.value.ToString();
        }
    }
}