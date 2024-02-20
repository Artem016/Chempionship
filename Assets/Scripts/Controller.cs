using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<GameObject> cubeGroup;
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100) && Input.GetMouseButtonDown(0))
        {
            if(hit.collider.tag == "cubeGroup")
            {
                hit.collider.transform.position = Vector3.zero;
                cubeGroup.Add(hit.collider.gameObject);
            }
        }
    }

    public IEnumerator RemoveSelectedGroup()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        foreach (GameObject go in cubeGroup)
        {
            Destroy(go);
        }
    }
}
