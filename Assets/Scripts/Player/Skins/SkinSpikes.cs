using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skin
{
    public class SkinSpikes : SkinItemBase
    {
        public override void Collect()
        {
            base.Collect();
            player.TouchDamage(duration);
        }

    }
}