using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    private GameObject currentFocusedObject;
    private ReactiveTarget currentFocusedTarget;

    void Start()
    {
        cam = GetComponent<Camera>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI() {
        int size = 12;
        float posX = cam.pixelWidth/2 - size/4;
        float posY = cam.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);
        Ray ray = cam.ScreenPointToRay(point);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            currentFocusedObject = hit.transform.gameObject;
            currentFocusedTarget = currentFocusedObject.GetComponent<ReactiveTarget>();
        } else  {
            currentFocusedObject = null;
            currentFocusedTarget = null;
        }

        if (currentFocusedTarget != null) {
            currentFocusedTarget.ShowStats();
        }

        if (Input.GetMouseButtonDown(0)) {
            if (currentFocusedTarget != null) {
                Debug.Log("Target Hit");
                currentFocusedTarget.ReactToHit(ray.direction);
            } else {
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
