using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject[] treePrefabs; // Tree prefabs to be randomly placed
    public GameObject sledArea; // Avoid placing trees in the sled area

    public int numTrees = 100;

    private Vector3 environmentSize;

    // Start is called before the first frame update
    void Start()
    {
        SetEnvironmentSize();
        PlaceTrees();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceTrees()
    {
        for (int i = 0; i < numTrees; i++)
        {
            // Get a random position on the plane
            Vector3 position = GetRandomTreePosition();

            // Pick a random tree
            int r = Random.Range(0, treePrefabs.Length);
            GameObject treePrefab = treePrefabs[r];

            Instantiate(treePrefab, position, Quaternion.identity);
        }
    }

    private Vector3 GetRandomTreePosition()
    {
        float hillWidth = environmentSize.x;
        float hillLength = environmentSize.z;

        // Get random offsets from the center of the plane
        float randomX = Random.Range(-1 * hillWidth / 2, hillWidth / 2);
        float randomZ = Random.Range(-1 * hillLength / 2, hillLength / 2);

        // Offset so that every point is instantiated above the highest point on the plane
        float verticalOffset = 100f;

        // Random point on plane (horizontal - not projected onto plane yet)
        Vector3 point = new Vector3(transform.position.x + randomX, transform.position.y + verticalOffset, transform.position.z + randomZ);

        // Project the point onto the plane by doing a raycast
        Vector3 projectedPoint;
        RaycastHit hit;
        if (Physics.Raycast(point, Vector3.down, out hit, Mathf.Infinity))
        {
            projectedPoint = hit.point;
        } else
        {
            projectedPoint = point;
        }

        return projectedPoint;
    }

    private void SetEnvironmentSize()
    {
        // Mesh filter stores vertex info for the bounding box of the mesh
        // Scale it by the plane's scale (applying the scale transformation of the gameobject)
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        environmentSize = Vector3.Scale(meshFilter.mesh.bounds.size, transform.localScale);
    }
}
