using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline;
using UnityEngine;

public class CubyControl : MonoBehaviour
{
    [SerializeField] CenterCell[] cells;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool ChekingActivaten() 
    {
        int counter = 0;
        foreach (var cell in cells) 
        {
            if(cell.isActivate) counter++;  
        }
        if(counter == 4) return true;
        return false;
    }
}
