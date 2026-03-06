using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 4f;
    [SerializeField] private float minZoom = 2f;
    [SerializeField] private float maxZoom = 20f;
    private float velocity = 0f;
    [SerializeField] private float smoothTime = 0.1f;
    [SerializeField] private float camSpeed = 10f;
    public GridManager Grid;
    

    [SerializeField] private Camera cam;

    private void Awake()
    {
        zoom = cam.orthographicSize;
        Grid = GameObject.Find("GridManager").GetComponent<GridManager>();
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);

        if (transform.position.x < Grid.width - 1f)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * camSpeed * Time.deltaTime);
            }
        }

        if (transform.position.y < Grid.height - 1f)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * camSpeed * Time.deltaTime);
            }
        }

        if (transform.position.x > 0f)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * camSpeed * Time.deltaTime);
            }
        }
        
        if (transform.position.y > 0f)
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * camSpeed * Time.deltaTime);
            }
        }
    }
}
