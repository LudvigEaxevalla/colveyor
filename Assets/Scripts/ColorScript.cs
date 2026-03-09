using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Color colorOneTest;
    public Color colorTwoTest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite.color = ColorMixer(colorOneTest, colorTwoTest);
    }

    public Color ColorMixer(Color colorOne, Color colorTwo)
    {
        Color mixedColor = Color.black;
          

        mixedColor = colorOne + colorTwo;

        return mixedColor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
