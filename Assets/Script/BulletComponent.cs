using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletComponent : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject,5f);
    }
}