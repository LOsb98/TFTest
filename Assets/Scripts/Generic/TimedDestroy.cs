using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float destroyTime;
    private float destroyTimer;

    void Start()
    {
        destroyTimer = destroyTime;
    }

    void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0) Destroy(gameObject, 0f);
    }
}
