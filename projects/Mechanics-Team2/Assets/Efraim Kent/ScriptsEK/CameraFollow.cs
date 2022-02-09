using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] float smoothTime = 0.1f;
    [SerializeField] float zoomSpeed = 1;
    [SerializeField] float minZoom = 15f;
    [SerializeField] float medZoom = 25f;
    [SerializeField] float maxZoom = 35f;

    Transform target;
    Vector3 offset;

    float startZoom;
    int zoomLevel, currentZoomLevel, zoomLevels = 3;

    void Start() {
        target = FindObjectOfType<PlayerControllerEK>().transform;
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        startZoom = target.position.z;
        offset = new Vector3(0, transform.position.y - target.position.y, 0);
    }

    void LateUpdate() {
        CameraZoom();
    }

    void CameraZoom(){
        if (Input.GetKeyDown(KeyCode.Z)) {
            var currentZoomLevel = zoomLevel % zoomLevels;
            //Change to minZoom
            if (currentZoomLevel == 0) {
                offset.y = minZoom;
            } else if (currentZoomLevel == 1) {
                offset.y = medZoom;
            } else if (currentZoomLevel == 2) {
                offset.y = maxZoom;
            } else {
                offset.y = startZoom;
            }
            zoomLevel++;
        }
    }
}
