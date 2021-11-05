using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public float health;

    void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }
}