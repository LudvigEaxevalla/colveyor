using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] private Color basecolor, offsetcolor;
    [SerializeField] private SpriteRenderer _renderer; 


    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? offsetcolor : basecolor;
    }

}
