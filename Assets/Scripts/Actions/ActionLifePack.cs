using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLifePack : MonoBehaviour
{
    public SOint soInt;
    public Itens.ItensManager itensManager;
    public Health health;
    public KeyCode keycode = KeyCode.H;
    private void Start()
    {
        soInt = itensManager.GetItemByType(Itens.ItemType.LIFE_PACK).soInt;
    }
    private void RecoverLife()
    {
        if(soInt.Value > 0)
        {
            itensManager.RemoveByType(Itens.ItemType.LIFE_PACK);
            health.ResetLife();
        }
    }
    public void Update()
    {
        if(Input.GetKeyDown(keycode))
        {
            RecoverLife();
        }
    }
}
