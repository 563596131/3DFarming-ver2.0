using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTool
{
    public static bool InRange(int value, int min, int max)
    {
        if (value >= min && value <= max)
        {
            return true;
        }

        return false;
    }

    public static bool InRangeExcludMax(int value, int min, int max)
    {
        if (value >= min && value < max)
        {
            return true;
        }

        return false;
    }
}
