using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Common
{
    /*
     * 使用方式：
     * 1.频繁使用的物体，通过对象池创建、回收、销毁
     * 2.需要通过对象池创建的物体，如需每次创建时执行，则让相应脚本实现IResetable接口
     * 
     */


    //用于外部调用时使用
        public interface IResetable
        {
            void OnReset();
        }

	public class GameObjectPool : MonoSingleton<GameObjectPool>
	{
        private Dictionary<string,List<GameObject>> cache;

        public override void Init()
        {
            base.Init();
            cache = new Dictionary<string,List<GameObject>>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="prefab"></param>
        /// <param name="pos"></param>
        /// <param name="rotate"></param>
        /// <returns></returns>
        public GameObject CreateObject(string key, GameObject prefab, Vector3 pos, Quaternion rotate)
        {
            GameObject go = null;
            if(cache.ContainsKey(key))
            {
                go = cache[key].Find(g => !g.activeInHierarchy);
            }
            if(go == null)
            {
                go = Instantiate(prefab);
                if(cache.ContainsKey(key))
                {
                    cache[key].Add(go);
                }
                else
                {
                    cache.Add(key,new List<GameObject>());
                    cache[key].Add(go);
                }

            }
            //使用
            go.transform.position = pos;
            go.transform.rotation = rotate;
            go.SetActive(true);
            //设置目标点
            //go.GetComponent<IResetable>().OnReset();
            //遍历执行物体中需要重置的逻辑
            foreach (var item in go.GetComponents<IResetable>())
            {
                item.OnReset();
            }
            //
            return go;
        }

        public void CollectObject(GameObject go,float delay=0)
        {
            if (delay == 0)
                go.SetActive(false);
            else           
                StartCoroutine(CollectObjectDelay(go, delay));
        }


        private IEnumerator CollectObjectDelay(GameObject go, float delay)
        {
            yield return new WaitForSeconds(delay);
            go.SetActive(false);
        }
        /// <summary>
        /// 清空某个类别
        /// </summary>
        /// <param name="key"></param>
        public void Clear(string key)
        {
            //Destroy 对象    倒着删除效率高，安全保证全部删除       
            for (int i = cache[key].Count-1; i >=0; i--)
			{
                Destroy(cache[key][i]);
			}
            //类别
                cache.Remove(key);
        }
        /// <summary>
        /// 清空全部
        /// </summary>
        public void ClearAll()
        {
//             foreach (var key in cache.Keys)//异常：无效操作，foreach最好只读，不用于修改
//             {
//                 Clear(key);
//             }

            foreach (var key in new List<string>(cache.Keys))
            {
                Clear(key);
            }
        }

	}
}
