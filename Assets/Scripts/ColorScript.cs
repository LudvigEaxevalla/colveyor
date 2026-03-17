using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Color colorA;
    public Color colorB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite.color = ColorMixer(colorA, colorB);
    }

    public Color ColorMixer(Color colorOne, Color colorTwo)
    {
        Color mixedColor = Color.black;
        mixedColor = Color.Lerp(colorOne, colorTwo, 0.5f);
        return mixedColor;
    }
    // Update is called once per frame
    void Update()
    {
        sprite.color = ColorMixer(colorA, colorB);

    }
}
