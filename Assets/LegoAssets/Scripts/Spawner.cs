using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Spawner : MonoBehaviour
{
    public EnemyController[] enemy;
    public GameObject[] spawnPoint;
    public string ConfFileName = "ConfigData.csv";
    Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();

    private void Awake() {
        ReadData();
    }
    private void ReadData()
    {
        StreamReader input = null;
        string path = "Assets/StreamingAssets";
        try
        {
            input = File.OpenText(Path.Combine(path,
                                        ConfFileName));
            string name = input.ReadLine();
            string values = input.ReadLine();
            while (values != null)
            {
                AssignData(values);
                values = input.ReadLine();
            }
        }
        catch (Exception ex) { Debug.Log(ex.Message); }
        finally { if (input != null) input.Close(); }
    }
void AssignData(string values)
    {
        string[] data = values.Split(',');
        float no = int.Parse(data[0]);
        string enemyName = data[1];
        float speed = float.Parse(data[2]);
        float size = float.Parse(data[3]);
        Enemy enemy = new Enemy(speed, size);
        enemies.Add(enemyName, enemy);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(enemy == null)
            return;
        if(spawnPoint == null)
            return;

        foreach(GameObject spawn in spawnPoint){
            int randomEnamy = UnityEngine.Random.Range(0,enemy.Length);
            string className = enemy[randomEnamy].GetType().Name;
            float moveSpeed = 3.5f;
            float xSize = 0f;
            Enemy enemyData = new Enemy(moveSpeed,xSize);
            switch(className){
                case "EnemyController" :
                    enemyData = enemies["EnemyController"];
                    break;
                case "GrayEnemy" :
                    enemyData = enemies["RedEnemy"];
                    break;
                case "RedEnemy" :
                    enemyData = enemies["GrayEnemy"];
                    break;
                default:
                    break;
            }

            enemy[randomEnamy].moveSpeed = enemyData.MoveSpeed;
            enemy[randomEnamy].xSize = enemyData.XSize;


            Instantiate(enemy[randomEnamy], spawn.transform.position, spawn.transform.rotation);
        }
    }

    
}
