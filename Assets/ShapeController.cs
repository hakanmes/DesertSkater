using UnityEngine;

public class ShapeController : MonoBehaviour
{
    public GameObject surfShapePrefab;
    public float moveSpeed = 5f;

    private GameObject currentSurfShape;
    private float surfShapeWidth;

    void Start()
    {
        currentSurfShape = Instantiate(surfShapePrefab, Vector3.zero, Quaternion.identity);
        surfShapeWidth = currentSurfShape.GetComponent<UnityEngine.U2D.SpriteShapeRenderer>().bounds.size.x;
    }

    void Update()
    {
        MoveSurf();
    }

    void MoveSurf()
    {
        float moveAmount = moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * moveAmount);

        // Check if we need to spawn a new surf shape
        if (transform.position.x < -surfShapeWidth)
        {
            SpawnNewSurfShape();
        }
    }

    void SpawnNewSurfShape()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + surfShapeWidth, transform.position.y, transform.position.z);
        currentSurfShape = Instantiate(surfShapePrefab, spawnPosition, Quaternion.identity);
    }
}