using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public int gridWidth = 10;
    public int gridHeight = 10;

    public float sphereRadius = 5f;
    public GameObject pointPrefab;

    [ContextMenu("Generate")]
    void GenerateGridOnSphere()
    {
        int numPoints = gridWidth * gridHeight; // Calculate the total number of points

        // Calculate the spacing between points in both longitude and latitude
        float thetaStep = 2f * Mathf.PI / gridWidth;
        float phiStep = Mathf.PI / gridHeight;

        for (int i = 0; i < numPoints; i++)
        {
            // Calculate the current row and column in the grid
            int row = i / gridWidth;
            int col = i % gridWidth;

            // Calculate the spherical coordinates for the current grid position
            float theta = col * thetaStep;
            float phi = row * phiStep;

            // Convert the spherical coordinates into Cartesian coordinates
            float xPos = sphereRadius * Mathf.Sin(phi) * Mathf.Cos(theta);
            float yPos = sphereRadius * Mathf.Cos(phi);
            float zPos = sphereRadius * Mathf.Sin(phi) * Mathf.Sin(theta);

            Vector3 pointPosition = new Vector3(xPos, yPos, zPos);
            Instantiate(pointPrefab, pointPosition, Quaternion.identity);
        }
    }
}