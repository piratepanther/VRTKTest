﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    //public static T Instance { get; private set;}
    public static T instance;
    
    public static T Instance
    { 
        get
        {
            if (instance == null)
            {
                //在场景中根据类型查找引用，没有这个类型，没往物体上挂T；
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    new GameObject("Singleton of"+typeof(T)).AddComponent<T>();
                }
                else
                {
                    instance.Init();
                }
                
            }
            return instance;
         }
    }

    protected void Awake()
    {
        if (instance == null) 
        {
            instance = this as T;
            Init();
        }
        
    }

    public virtual void Init()
    {

    }


}
