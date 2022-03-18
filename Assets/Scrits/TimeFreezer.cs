using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezer : PickUp
{
    public int freezeTime;
    public override void Picked()
    {
        GameManager.gameManager.FrezeeTime(freezeTime);
        Destroy(this.gameObject);

    }
   
}

