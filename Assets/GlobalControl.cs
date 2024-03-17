using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    private static int avatarID = -1;

    public static int GetAvatarID()
    {
        return avatarID;
    }

    public static void SetAvatarID(int value)
    {
        avatarID = value;
    }

    void Awake()
    {
        if (Instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }


}
