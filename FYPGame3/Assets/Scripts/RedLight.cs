using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RedLight 
{
    public static GameObject barricade;
    // Start is called before the first frame update

    // Update is called once per frame

    public static void Barricade()
    {
        barricade.SetActive(true);
    }
}
