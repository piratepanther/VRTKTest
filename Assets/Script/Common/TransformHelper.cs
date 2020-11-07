using UnityEngine;

namespace Common 
{ 
    public static class TransformHelper
       {
        public static Transform FindChildByName(this Transform currentTF, string childName)
            {
                Transform childTF = currentTF.Find(childName);
                if (childTF != null) return childTF;
                for (int i = 0; i < currentTF.childCount; i++)
			        {
                        childTF = FindChildByName(currentTF.GetChild(i), childName);
                        if (childTF != null) return childTF;			 
			        }
                return null;
            }
        /// <summary>
        /// 注视方向旋转渐变
        /// </summary>
        /// <param name="currentTF"></param>
        /// <param name="direction"></param>
        /// <param name="rotateSpeed"></param>
        public static void LookAtDirection(this Transform currentTF, Vector3 direction, float rotateSpeed)
            {
                if (direction == Vector3.zero) return;
                Quaternion lookDir = Quaternion.LookRotation(direction);
                currentTF.rotation = Quaternion.Lerp(currentTF.rotation, lookDir, rotateSpeed * Time.deltaTime);
            }
        /// <summary>
        /// 注视位置旋转渐变
        /// </summary>
        /// <param name="currentTF"></param>
        /// <param name="position"></param>
        /// <param name="rotateSpeed"></param>
        public static void LookAtPosition(this Transform currentTF, Vector3 position, float rotateSpeed)
        {
            Vector3 direction = position - currentTF.position;
            currentTF.LookAtDirection(direction, rotateSpeed);
        }


    }
}