using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Zoom : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    GameObject selectedObject;
    Camera camera;
    [SerializeField] AssetReferenceGameObject assetReference;

    GameObject loadGameObject;

    void Start()
    {
        camera = Camera.main;
    }

    private void OnLoadCompleted(AsyncOperationHandle<GameObject> handle)
    {


        if (handle.Status == AsyncOperationStatus.Succeeded)
        {

            loadGameObject = Instantiate(handle.Result);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000) && Input.GetMouseButtonDown(0))
        {
            selectedObject = hit.collider.gameObject;
            camera.transform.position = selectedObject.transform.position + new Vector3(0, 2, 0);

            Addressables.LoadAssetsAsync<GameObject>(assetReference, (gameObj) =>
            {
                Debug.Log(gameObj);
            });

            assetReference.InstantiateAsync(selectedObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity).Completed += (asyncOperation) => loadGameObject = asyncOperation.Result;
        }



        if (Input.GetMouseButtonDown(1))
        {
            if (loadGameObject != null) 
            {
                Addressables.ReleaseInstance(loadGameObject);
            }

            camera.transform.position = new Vector3(0, 10, 0);
        }
    }
}

