using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ConveyorBeltScript : MonoBehaviour
{

    public GameObject currentTile;

    [System.Serializable]
    public class ConveyorBeltItem
    {
        public Transform item;
        [HideInInspector] public float currentLerp;
        public int endPoint = 1;
        
    }

    [SerializeField] private float itemSpacing;
    [SerializeField] private float speed;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private List<ConveyorBeltItem> items;

    public bool isPlacing = false;
    public int beltIndex;





    public void Update()
    {



        if (isPlacing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (beltIndex != 0)
                {
                    lineRenderer.positionCount++;
                }
               // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lineRenderer.SetPosition(beltIndex, currentTile.transform.position);
                beltIndex++;
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items [i].item != null) 
            { 

                ConveyorBeltItem beltItem = items[i];
                Transform item = items[i].item;

                if (i > 0)
                {
                    if (Vector3.Distance(a:item.position, b: items[i-1].item.position) <= itemSpacing)
                    {
                        continue;
                    }

                }


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

}
