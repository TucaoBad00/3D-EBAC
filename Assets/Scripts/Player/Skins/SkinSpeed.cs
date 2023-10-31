using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Skin
{
    public class SkinSpeed : SkinItemBase
    {
        public float speed = 30;
        public override void Collect()
        {
            base.Collect();
            player.ChangeSpeed(speed, duration);
        }
    }
}