using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditorInternal;
using UnityEngine;

public class ChunkManager : MonoBehaviour {
    public static ChunkManager instance;
    
    
    [Header(" Elements ")]
    [SerializeField] private LevelSO[] levels;


    private void Awake() {

        if (instance !=null) {
            Destroy(gameObject);


        }
        else {
            instance = this;
        }
        
        
    }


    private void Start() {

        GenerateLevel();

    }

    private void GenerateLevel() {

        int currentLevel = GetLevel();
        currentLevel = currentLevel % levels.Length;
        LevelSO level = levels[currentLevel];
        CreateLevel(level.chunks);

    }

   /*private void CreateLevel(Chunk[] levelChunks) {


        Vector3 chunkPosition = Vector3.zero;

        for (int i = 0; i< levelChunks.Length; i++) {

            Chunk chunkToCreate = levelChunks[i];

            chunkPosition.y = -4.6f;
            

            if (i>0) {

                chunkPosition.z += chunkToCreate.GetLength() / 2;


            }

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength()/2;

        }
        


    }*/
   
   private void CreateLevel(Chunk[] levelChunks)
{
    
    Vector3 nextPosition = Vector3.zero;
    Quaternion nextRotate = Quaternion.identity; 

    for (int i = 0; i < levelChunks.Length; i++)
    {
        Chunk chunkPrefab = levelChunks[i];

        
        Chunk chunkInstance = Instantiate(chunkPrefab, nextPosition, nextRotate, transform);

       
        nextPosition = chunkInstance.BitisNoktasi.position;
        nextRotate = chunkInstance.BitisNoktasi.rotation;
    }
}


    private int GetLevel() {

        return PlayerPrefs.GetInt("levels", 0);

    }
}
