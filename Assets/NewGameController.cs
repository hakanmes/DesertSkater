using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameController : MonoBehaviour
{
    public GameObject objPrefab;
    public float spawnInterval = 2f;

    private void Start()
    {
        // İlk objeyi başlangıçta oluştur
        SpawnObject();
        // Daha sonra belirli aralıklarla tekrar et
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }

   private void SpawnObject()
    {
        // Bir önceki objeyi al
        GameObject lastSpawnedObject = GameObject.FindWithTag("SurfPiece");
        Vector3 spawnPosition = Vector3.zero; // Varsayılan olarak (0,0,0)

        // Eğer bir önceki obje varsa, onun sağ üst noktasını al
        if (lastSpawnedObject != null)
        {
            Renderer lastObjectRenderer = lastSpawnedObject.GetComponent<Renderer>();
            if (lastObjectRenderer != null)
            {
                Bounds lastObjectBounds = lastObjectRenderer.bounds;
                // Yeni objenin sol üst noktasını bir önceki objenin sağ üst noktasına ayarla
                spawnPosition.x = lastObjectBounds.max.x;
                spawnPosition.y = lastObjectBounds.max.y;
            }
        }

        // Yeni objenin boyutlarını al
        Renderer newObjectRenderer = objPrefab.GetComponent<Renderer>();
        Bounds newObjectBounds = newObjectRenderer.bounds;

        // Yeni objenin sol üst noktasını bir önceki objenin sağ üst noktasına yerleştir
        spawnPosition.x += newObjectBounds.extents.x;
        spawnPosition.y -= newObjectBounds.extents.y;

        // Yeni objeyi oluştur ve konumunu ayarla
        GameObject newObject = Instantiate(objPrefab, spawnPosition, Quaternion.identity);
        // Oluşturulan objeyi etiketle
        newObject.tag = "SurfPiece";
    }
}
