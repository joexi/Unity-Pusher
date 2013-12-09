using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class Pusher : MonoBehaviour {
    private static GameObject Host = new GameObject();
    private static GameObject LockObj = new GameObject();
    private static List<Action> actions = new List<Action>();

    public static void Instantiate()
    {
        if (Host.GetComponent<Pusher>() == null)
        {
            Pusher pusher = Host.AddComponent<Pusher>();
            Host.name = "Global_Pusher";
            LockObj.name = "Lock";
            LockObj.transform.parent = Host.transform;
            DontDestroyOnLoad(Host);
            DontDestroyOnLoad(LockObj);
        }
    }

	void Start () {
        
	}
	

	void Update () {
        this.push();
	}

    void Awake()
    {
        
    }

    void push()
    {
        lock (LockObj)
        {
            try
            {
                foreach(Action act in actions)
                {
                    act.Invoke();
                }
                actions.Clear();
            }
            catch
            {
                actions.Clear();
            }
        }
    }

    public static void Run(Action action)
    {
        lock(LockObj)
        {
            actions.Add(action);
        }
    }
}
