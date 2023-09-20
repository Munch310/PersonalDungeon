using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    //public Action<int> onSlotCountChange;

    private int slotCnt;

    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange?.Invoke(slotCnt);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SlotCnt = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
