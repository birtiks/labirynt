using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public colorToPrefab[] colorMappings;
    public float offset = 5f;

    public void GenerateLabirynth()
    {
        for(int x=0;x<map.width,x++)
        {
            for(int z=0; z<map.height;z++)
            {
                GenerateTile(x, z);
            }
        }
    }

    void GenerateTile( int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        if (pixelColor.a == 0)
            return;
        foreach(colorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0f, z) * offset;
                Instantiate(colorMapping.prefab,
                    position,
                    Quaternion.identity,
                    transform);
            }
        }
    }
}
