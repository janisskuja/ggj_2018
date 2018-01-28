using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Generator : MonoBehaviour
{
    public static Generator instance;

    public int TileCountX;
    public int TileCountZ;
    public GameObject TilePrefab;
    public int TargetCount;
    public GameObject RedTargetPrefab;
	public GameObject BlueTargetPrefab;
    public float TargetMinSpreadDistance;
    public float TargetDistanceFromSides;
    public float blueRewapawnRate;
    public float redRewapawnRate;
    private float nextPowerUpRed;
    public float redScore;
    public float blueScore;

    public GameObject PowerUpPrefab;
    private bool powerUpRedNeeded = true;
    private bool powerUpBlueNeeded = true;

    private List<Vector3> spawnedTargets;
    private float nextPowerUp;

    public void Awake()
    {
        if (instance == null) instance = this;
    }

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
            var targetX =  Random.Range(0 + TargetDistanceFromSides, xMax - TargetDistanceFromSides);
            var targetZ =  Random.Range(zMin + TargetDistanceFromSides, zMax - TargetDistanceFromSides);
            if (spawnedTargets.Any())
                while (spawnedTargets.FirstOrDefault(t =>
                    t.x < targetX + TargetMinSpreadDistance
                    && t.x > targetX - TargetMinSpreadDistance
                    || t.z < targetZ + TargetMinSpreadDistance
                    && t.z > targetZ - TargetMinSpreadDistance) != Vector3.zero)
                {
                    targetX = Random.Range(0 + TargetDistanceFromSides, xMax - TargetDistanceFromSides);
                    targetZ = Random.Range(zMin + TargetDistanceFromSides, zMax - TargetDistanceFromSides);
                    tryCount++;
                    if (tryCount > 50)
                    {
                        break;
                    }
                }
            var blueTargetPos = new Vector3(targetX, 2, targetZ);
			var redTargetPos = new Vector3(-targetX, 2, targetZ);
			spawnedTargets.Add(blueTargetPos);
			spawnedTargets.Add(redTargetPos);

			var target = Instantiate(BlueTargetPrefab, blueTargetPos, Quaternion.identity);
			var targetRed = Instantiate(RedTargetPrefab, redTargetPos, Quaternion.identity);
            target.GetComponent<Target>().TeamBlue = true;
            targetRed.GetComponent<Target>().TeamBlue = false;

        }
    }
    
    public void AskForSpawn(bool teamBlue)
    {
		if (powerUpBlueNeeded == false && teamBlue)
        {
            nextPowerUp = Time.time + blueRewapawnRate;
            powerUpBlueNeeded = true;
            Debug.Log(" blue");
        }

		if (powerUpRedNeeded == false && !teamBlue)
        {
            nextPowerUpRed = Time.time + redRewapawnRate;
            powerUpRedNeeded = true;
            Debug.Log(" red");
        }

    }

    private void Update()
    {
        var xMax = TileCountX / 2;
        var zMin = -(TileCountZ / 2);
        var zMax = TileCountZ / 2;

        if (powerUpBlueNeeded && Time.time > nextPowerUp)
        {     
	        var powerUpX = Random.Range(0 + TargetDistanceFromSides, xMax - TargetDistanceFromSides);
	        var powerUpZ = Random.Range(zMin + TargetDistanceFromSides, zMax - TargetDistanceFromSides);
	        var powerUpPos = new Vector3(powerUpX, 2, powerUpZ);
			var powerUp = Instantiate(PowerUpPrefab, powerUpPos, Quaternion.identity);
	        powerUp.GetComponent<PowerUp>().TeamBlue = true;
	        powerUpBlueNeeded = false;
        }

        if (powerUpRedNeeded && Time.time > nextPowerUpRed)
        {
            var powerUpX = Random.Range(0 + TargetDistanceFromSides, xMax - TargetDistanceFromSides);
            var powerUpZ = Random.Range(zMin + TargetDistanceFromSides, zMax - TargetDistanceFromSides);
            var powerUpPos = new Vector3(-powerUpX, 2, powerUpZ);
			var powerUpRed = Instantiate(PowerUpPrefab, powerUpPos, Quaternion.identity);
            powerUpRed.GetComponent<PowerUp>().TeamBlue = false;
            powerUpRedNeeded = false;
        }
    }
}