using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rack
{
    private bool[] rack;

    public Rack()
    {
        rack = new bool[7];
        for (int i = 0; i < 6; i++)
            rack[i] = false; // true means that the rack is empty , false means that there is a tile
    }

    public void setRack(int index, bool value)
    {
        rack[index] = value;
    }

    public bool getRack(int index)
    {
        return rack[index];
    }
}
