using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCell : MonoBehaviour
{
    Controller controller;
    CubyControl cubyControl;
    [SerializeField] Material material;
    public bool isActivate = false;
    // Start is called before the first frame update
    private void Start()
    {
        controller = Camera.main.GetComponent<Controller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().material = material;
        cubyControl = other.GetComponentInParent<CubyControl>();
        isActivate = true;
        if (cubyControl.ChekingActivaten())
        {
            StartCoroutine(controller.RemoveSelectedGroup());
        }
    }


}
