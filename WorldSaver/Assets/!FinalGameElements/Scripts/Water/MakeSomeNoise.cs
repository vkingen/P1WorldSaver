using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kilde til script https://www.youtube.com/watch?v=3MoHJtBnn2U
public class MakeSomeNoise : MonoBehaviour
{
    public float power = 3f;
    public float scale = 1f;
    public float timeScale = 1f;

    private float xOffset;
    private float yOffset;
    private MeshFilter mf;


    // Start is called before the first frame update
    void Start()
    {
        mf = GetComponent<MeshFilter>();
        MakeNoise();

    }

    // Update is called once per frame
    void Update()
    {
        MakeNoise();
        xOffset += Time.deltaTime * timeScale;
        if (yOffset <= 0.3) yOffset += Time.deltaTime * timeScale;
        if (yOffset >= power) yOffset -= Time.deltaTime * timeScale;
    }

    void MakeNoise()
    {
        Vector3[] verticies = mf.mesh.vertices;

        for (int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;            
        }

        mf.mesh.vertices = verticies;
    }

    float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + xOffset;
        float yCord = y * scale + yOffset;
        return Mathf.PerlinNoise(xCord, yCord);
    }
}
