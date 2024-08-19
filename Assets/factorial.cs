using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factorial : MonoBehaviour
{

    private void Start()
    {
        int sum = Calculate(5);
        Debug.Log($"{sum}");
    }

    private int Calculate(int value)
    {
        if (value == 0)
            return 1;

        return value * Calculate(value-1);
    }

}
