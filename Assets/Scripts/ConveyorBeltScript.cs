using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ConveyorBeltScript : MonoBehaviour
{

    [System.Serializable]
    public class ConveyorBeltItem
    {
        public Transform item;
        [HideInInspector] public float currentLerp;
        [HideInInspector] public int endPoint = 1;
        
    }

    [SerializeField] private float speed;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private List<ConveyorBeltItem> items;

    private void Update()
    {
        for (int i = 0; i < items.Count; i++)
        {
            ConveyorBeltItem beltItem = items[i];
            Transform item = items[i].item;


            item.transform.position = Vector3.Lerp(a: lineRenderer.GetPosition(index: beltItem.endPoint - 1), b: lineRenderer.GetPosition(beltItem.endPoint), beltItem.currentLerp);
            float distance = Vector3.Distance(a: lineRenderer.GetPosition(index: beltItem.endPoint - 1), b: lineRenderer.GetPosition(beltItem.endPoint));
            beltItem.currentLerp += (speed * Time.deltaTime) / distance;

            if (beltItem.currentLerp >= 1)
            {

                if (beltItem.endPoint + 1 < lineRenderer.positionCount)
                {
                    beltItem.currentLerp = 0;
                    beltItem.endPoint++;
                }
            } 
        }
    }

}
