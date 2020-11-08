using UnityEngine;
using System.Collections;

namespace Assets.Script.FSM2.SpawnSystem
{
    /// <summary>
    /// 生成器系统
    /// </summary>
    public class SpawnSystem : MonoSingleton<SpawnSystem>
    {

        private GameObject[] spawnGoArray;
        private int currentIndex = -1;

        //管理生成器
        private new void Awake()
        {
            base.Awake();
            spawnGoArray = new GameObject[transform.childCount];

            for (int i = 0; i < spawnGoArray.Length; i++)
            {
                spawnGoArray[i] = transform.GetChild(i).gameObject;
                //禁用子物体
                spawnGoArray[i].SetActive(false);
                //禁用孙子物体
                spawnGoArray[i].GetComponentInChildren<EnemySpawn>().gameObject.SetActive(false);


            }



        }

        //激活下一个生成器(单机游戏开始调用，所有敌人死亡调用)
        public void ActivateNextSpawn()
        {
            if(currentIndex < spawnGoArray.Length - 1)
            {
                currentIndex++;
                spawnGoArray[currentIndex].SetActive(true);

            }
            else
            {
                Debug.Log("game over");

            }
        }


    }
}