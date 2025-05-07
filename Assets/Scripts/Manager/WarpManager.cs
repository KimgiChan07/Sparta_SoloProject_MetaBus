using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager : MonoBehaviour
{
    static WarpManager warpObject;
    public static WarpManager Instance { get; private set; }
    
    [System.Serializable]
    public class WarpObjectData
    {
        public string warpName;
        public Transform target;
    }
    
    [SerializeField] private Transform player;
    [SerializeField] private List<WarpObjectData> warpObjects;
    
    private Dictionary<string, Transform> warpDictionary;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        
        warpDictionary= new Dictionary<string, Transform>();
        foreach (var warp in warpObjects)
        {
            if (!warpDictionary.ContainsKey(warp.warpName))
            {
                warpDictionary.Add(warp.warpName, warp.target);
            }
        
    }
    }

    public void WarpPlayer(string warpName)
    {

        if (warpDictionary.TryGetValue(warpName, out var target))
        {
            player.position = target.position;
        }
        else
        {
            
        }
    }
}
