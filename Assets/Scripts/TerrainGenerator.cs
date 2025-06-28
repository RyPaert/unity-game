using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
	public GameObject dirtPrefab;
	public GameObject stonePrefab;

	public int chunkSize = 32;
	public float noiseScale = 0.1f;
	public int terrainHeight = 10;

	private void Start()
	{
		GenerateTerrain();
	}

	void GenerateTerrain()
	{
		int halfChunkSize = chunkSize / 2;

		for (int x = -halfChunkSize; x < halfChunkSize; x++)
		{
			for (int z = -halfChunkSize; z < halfChunkSize; z++)
			{
				int totalHeight = (int)(Mathf.PerlinNoise((x + halfChunkSize) * noiseScale, (z + halfChunkSize) * noiseScale) * terrainHeight);

				for (int y = 0; y <= totalHeight; y++)
				{
					//Instantiate(dirtPrefab, new Vector3(x, y, z), Quaternion.identity);

					GameObject newBlock;
					if (y == totalHeight)
					{
						newBlock = Instantiate(dirtPrefab, new Vector3(x, y, z), Quaternion.identity);
					}
                    else
                    {
						newBlock = Instantiate(stonePrefab, new Vector3(x, y, z), Quaternion.identity);
                    }
					
                }		
			}
		}
	}
}
