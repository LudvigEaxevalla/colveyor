using Unity.VisualScripting;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mouseWorldPosition = Input.mousePosition;
        }
    }
}
