using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("Rubble"))
        {
            Destroy(other.gameObject);
        }
    }
}
