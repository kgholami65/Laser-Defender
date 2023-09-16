using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamageDealer : DamageDealer
{
    public override void Hit()
    {
        Destroy(gameObject);
    }
}
