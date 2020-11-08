using UnityEngine;
using System.Collections;
using Common;

namespace Assets.Script.FSM2.SpawnSystem
{
    public class SpawnTrigger : MonoBehaviour
    {
        /// <summary>
        /// 生成器触发器，如果与玩家接触，则禁用自身启用生成器
        /// </summary>

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "player")
            {
                transform.parent.FindChildByName("WayLineRoot").gameObject.SetActive(true);
                gameObject.SetActive(false);

            }
        }



    }
}