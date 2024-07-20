using System.Collections.Generic;
using UnityEngine;

public class GroundRandomPos : MonoBehaviour
{
    public Transform player;
    public List<GameObject> listGround;
    public List<GameObject> listGroundOld;

    public Vector3 endPos;
    public Vector3 nextPos;
    int groundLen;

    public GameObject plant;
    public GameObject Boar;
    public GameObject BoarLeft;

    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(27f, 0f, 0f);

        for (int i = 0; i < 5; i++)
        {
            float khoangCach = Random.Range(2f, 5f);
            nextPos = new Vector3(endPos.x + khoangCach, 0f, 0f);
            int groundID = Random.Range(0, listGround.Count);

            GameObject nGround =  Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
            listGroundOld.Add(nGround);

            switch (groundID)
            {
                case 0: groundLen = 6; break;
                case 1: groundLen = 12; break;
                case 2: groundLen = 16; break;
                case 3: groundLen = 17; break;
                case 4: groundLen = 21; break;
                case 5: groundLen = 27; break;
            }

            endPos = new Vector3(nextPos.x + groundLen, 0f, 0f);    
            
            if(groundID == 5)
            {
                SpawnBoar();
            }
            else
            {
                int getEnemy = Random.Range(0, 2);
                if(getEnemy != 0)
                {
                    SpawnPlant();
                }
                else
                {
                    SpawnBoarLeft();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position,endPos) < 50f)
        {
            for (int i = 0; i < 5; i++)
            {
                float khoangCach = Random.Range(2f, 5f);
                nextPos = new Vector3(endPos.x + khoangCach, 0f, 0f);
                int groundID = Random.Range(0, listGround.Count);

                GameObject nGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
                listGroundOld.Add(nGround);

                switch (groundID)
                {
                    case 0: groundLen = 6; break;
                    case 1: groundLen = 12; break;
                    case 2: groundLen = 16; break;
                    case 3: groundLen = 17; break;
                    case 4: groundLen = 21; break;
                    case 5: groundLen = 27; break;
                }

                endPos = new Vector3(nextPos.x + groundLen, 0f, 0f);

                if(groundID == 5)
                {
                    SpawnBoar();
                }
                else
                {
                    int rdEnemy = Random.Range(0, 2);
                    if(rdEnemy == 0)
                    {
                        SpawnPlant();
                    }
                    else
                    {
                        SpawnBoarLeft();
                    }
                }
            }
        }

        if(Vector2.Distance(player.position, listGroundOld[0].transform.position) > 50f)
        {
            GameObject getFirst = listGroundOld[0]; //lấy gameObject đầu tiên ra
            listGroundOld.RemoveAt(0); //xóa nó khỏi danh sách
            Destroy(getFirst); //Xóa gameObject khỏi Hierarchy
        }
    }
    
    public void SpawnPlant()
    {
        float posX = Random.Range(nextPos.x + 2f, endPos.x - 2f);
        Vector3 pos = new Vector3(posX, 0, 0);

        Instantiate(plant, pos, Quaternion.identity);
    }

    public void SpawnBoar() //-7 -> 7
    {
        float posX = Random.Range(nextPos.x + 8f, endPos.x - 8f);
        Vector3 pos = new Vector3(posX, 0, 0);

        Instantiate(Boar, pos, Quaternion.identity);
    }

    public void SpawnBoarLeft()//chỉ di chuyển qua trái
    {
        float posX = Random.Range(endPos.x - 5f, endPos.x - 3f);
        Vector3 pos = new Vector3(posX, 0, 0);

        Instantiate(BoarLeft, pos, Quaternion.identity);
    }
}
