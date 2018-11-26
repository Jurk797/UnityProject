﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if(_instance == null)
                {
                    Debug.LogError("Singleton: " + typeof(T) + " не найден");
                }
            }
            return _instance;
        }
    }
}
