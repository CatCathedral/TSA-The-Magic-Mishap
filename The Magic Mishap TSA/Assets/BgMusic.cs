using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bgmusic : MonoBehaviour
{
    public static Bgmusic instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
 
