using UnityEngine;
using System.Collections;
using Common;

namespace Assets.Script.FSM2
{
    /// <summary>
    /// 敌人生成器
    /// </summary>
    public class EnemySpawn : MonoBehaviour
    {
        private Vector3[][] wayPaths;
        [Tooltip("最小最大延迟时间")]
        public float minDelay = 1;
        public float maxDelay = 5;
        [Tooltip("产生的敌人预制件")]
        public GameObject[] enemyPrefabs;//public Srting[] enemyPrefabs



        private void Start()
        {
            CalculateWayPath();
            StartCoroutine( GenerateEnemy());
        }

        //生成路线
        private void CalculateWayPath()
        {
            //创建交错数组（元素：路线，元素的元素：路点坐标）
            wayPaths = new Vector3[transform.childCount][];
            for (int i = 0; i < wayPaths.Length; i++)
            {
                Transform childTF = transform.GetChild(i);
                wayPaths[i] = new Vector3[childTF.childCount];
                for (int j = 0; j < wayPaths[i].Length; j++)
                {
                    wayPaths[i][j] = childTF.GetChild(j).position;
                }

            }

        }

        //生成敌人
        
        public IEnumerator GenerateEnemy()
        {
            //根据路线wayPaths.Length创建敌人
            for (int i = 0; i < wayPaths.Length; i++)
            {
                //时间随机

                yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

                //创建敌人对象

                CreatEnemyGo(wayPaths[i]);

            }


        }

        //创建敌人对象
        private void CreatEnemyGo(Vector3[] path)
        {
            //类型随机，指定路线

            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            GameObject enemyGo = GameObjectPool.instance.CreateObject(prefab.name, prefab, path[0],Quaternion.identity);

            enemyGo.GetComponent<FSMBase>().wayPoints = path;



        }


    }
}