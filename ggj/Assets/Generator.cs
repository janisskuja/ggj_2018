using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int TileCountX;
    public int TileCountZ;
    public GameObject TilePrefab;
    public int TargetCount;
    public GameObject TargetPrefab;
    public float TargetMinSpreadDistance;
    public float TargetDistanceFromSides;
    private List<Vector3> spawnedTargets;
    public void Start()
    {
        spawnedTargets = new List<Vector3>();
        var xMin = -(TileCountX / 2);
        var xMax = TileCountX / 2;
        var zMin = -(TileCountZ / 2);
        var zMax = TileCountZ / 2 ;

        for (var x = xMin; x < xMax; x++)
        {
            for (var z = zMin; z < zMax; z++)
            {
                var tile = Instantiate(TilePrefab);
                tile.transform.position = new Vector3(x, 0, z);
                GridCube cube = tile.GetComponent<GridCube>();
                cube.isBlue = x > 0;
            }
        }
        var tryCount = 0;
        for (var i = 0; i < TargetCount; i++)
        {
            var targetX =  Random.Range(xMin + TargetDistanceFromSides, xMax - TargetDistanceFromSides);
            var targetZ =  Random.Range(zMin + TargetDistanceFromSides, zMax - TargetDistanceFromSides);
            if (spawnedTargets.Any())
                while (spawnedTargets.FirstOrDefault(t =>
                    t.x < targetX + TargetMinSpreadDistance
                    && t.x > targetX - TargetMinSpreadDistance
                    || t.z < targetZ + TargetMinSpreadDistance
                    && t.z > targetZ - TargetMinSpreadDistance) != Vector3.zero)
                {
                    targetX = Random.Range(xMin + TargetDistanceFromSides, xMax - TargetDistanceFromSides);
                    targetZ = Random.Range(zMin + TargetDistanceFromSides, zMax - TargetDistanceFromSides);
                    tryCount++;
                    Debug.Log(targetX + " fail ");
                    if (tryCount > 50)
                    {
                        break;
                    }
                }
            var targetPos = new Vector3(targetX, 0, targetZ);
            spawnedTargets.Add(targetPos);

            var target = Instantiate(TargetPrefab);
            var targetRed = Instantiate(TargetPrefab);
            target.transform.position = targetPos;
            targetRed.transform.position = -target.transform.position;

        }
    }
}