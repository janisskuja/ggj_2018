using UnityEngine;

public class Generator : MonoBehaviour
{
	public int TileCountX;
	public int TileCountZ;
	public GameObject TilePrefab;

	public void Start()
	{
		for (var x = -(TileCountX / 2); x < TileCountX / 2; x++)
		{
			for (var z = -(TileCountZ / 2); z < TileCountZ / 2; z++)
			{
				var tile = Instantiate(TilePrefab);
				tile.transform.position = new Vector3(x, 0, z);
				GridCube cube = tile.GetComponent<GridCube>();
				cube.isBlue = x > 0;
			}
		}
	}
}