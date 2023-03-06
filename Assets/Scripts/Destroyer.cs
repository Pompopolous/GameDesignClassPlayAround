using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject explosion;
    public void destroyExplosion()
    {
        Destroy(this.gameObject);
    }
}
