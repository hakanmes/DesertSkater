using UnityEngine;
using System;


public class SurfPieceController : MonoBehaviour
{
    public GameObject[] surfPiecePrefab;
    public float moveSpeed = 5f;
    public float surfPieceWidth = 10f;
    public float timer = 0;
    float yeni2timer = 0 ;
    private Transform playerTransform;
    Vector3 spawnPosition;
    Vector3 spawnPosition2;
    Vector3 spawnXX;
    System.Random random;
    int randomIndex;
    Collider2D collider;
    Collider2D collider2;
    GameObject rasgeleNesne1;
    GameObject rasgeleNesne2;
    Vector3 prefabLowerRight;
    Vector3 prefabUpperRight;
     Vector3 prefabLowerRight2;
    Vector3 prefabUpperRight2;
    bool choosing = false;
    bool yeni1 = false;
    bool yeni2 = false;
    private float spawnX = -5f; // Oyun başladığında oluşturulan ilk parçanın X pozisyonu
    private float destroyX = -15f; // Ekrandan çıkan parçaların X pozisyonu
    public int numberOfCopies = 5; // Oluşturulacak kopya sayısı
    //public float spacing = 3.0f;

    void Start()
    {
        timer = 3f;
        spawnPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // "Player" etiketini kullanarak oyuncu objesini bul
    }

    void Update()
    {
        
        if(timer>2)
        {
            random = new System.Random();
            randomIndex = random.Next(surfPiecePrefab.Length);
            rasgeleNesne1 = surfPiecePrefab[randomIndex];
            rasgeleNesne2 = surfPiecePrefab[randomIndex];
            choosing = true;
            yeni1 = true;
            collider = rasgeleNesne1.GetComponent<Collider2D>();
            collider2 = rasgeleNesne2.GetComponent<Collider2D>();
            timer = 0;
        }
        
        if(yeni2 == false)
        {
            timer += Time.deltaTime;
        }
        // Oyuncunun pozisyonuna bağlı olarak yeni parçalar oluştur ve eski parçaları kaldır
        if (choosing)
        {
                //yeni2timer += Time.deltaTime;
               
                Bounds bounds = collider.bounds;
                 Bounds bounds2 = collider2.bounds;

                float offsetX;
                float offsetY;
                float offsetX2;
                float offsetY2;
                
                if(yeni1)
                {
                    GameObject yeniNesne1 = Instantiate(rasgeleNesne1, spawnPosition, transform.rotation);
                    prefabUpperRight = bounds.max;
                    prefabLowerRight = bounds.min;
                    offsetX = prefabUpperRight.x - prefabLowerRight.x;
                    offsetY = prefabUpperRight.y - prefabLowerRight.y;
                    spawnPosition2.x += offsetX;
                    yeni1 = false;
                    yeni2 = true;
                    Debug.Log("yeni1");
                    
                }
                
                if(yeni2)
                {
                    yeni2timer += Time.deltaTime;
                    if(yeni2timer > 2)
                    {
                        Debug.Log("yeni2");
                        GameObject yeniNesne2 = Instantiate(rasgeleNesne2, spawnPosition2, transform.rotation);
                        prefabUpperRight2 = bounds2.max;
                        prefabLowerRight2 = bounds2.min;
                        offsetX2 = prefabUpperRight2.x - prefabLowerRight2.x;
                        offsetY2 = prefabUpperRight2.y - prefabLowerRight2.y;
                        spawnPosition.x += offsetX2;
                        yeni2 =false;
                        choosing = false;
                        yeni2timer = 0;
                        yeni2= false;
                    }
                    
                    
                }

                
                //GameObject newObstacle5 = Instantiate(powerDowns[Random.Range(0,powerDowns.Length)]);
                

                // Prefab'ın sağ üst ve alt köşelerini al
                //Vector3 prefabUpperRight = bounds.max;
                //Vector3 prefabLowerRight = bounds.min;
                
                // Sonraki prefab'ın konumunu güncelle
                //offsetX = prefabUpperRight.x - prefabLowerRight.x;
                //offsetY = prefabUpperRight.y - prefabLowerRight.y;
                //spawnPosition.x += offsetX;
                //spawnPosition.y += -offsetY;
                //spawnPosition += -transform.up * offsetY;

                // Bir sonraki objenin konumunu güncelle

                
        }

        /*if (playerTransform.position.x < (destroyX + surfPieceWidth))
        {
            DestroySurfPiece();
        }*/
    }

    void SpawnSurfPiece()
    {
        
        
        
        
    }

    /*void DestroySurfPiece()
    {
        GameObject[] surfPieces = GameObject.FindGameObjectsWithTag("SurfPiece");
        if (surfPieces.Length > 0)
        {
            GameObject oldestPiece = surfPieces[0];
            foreach (var piece in surfPieces)
            {
                if (piece.transform.position.x < oldestPiece.transform.position.x)
                {
                    oldestPiece = piece;
                }
            }
            Destroy(oldestPiece);
        }
    }*/
}
