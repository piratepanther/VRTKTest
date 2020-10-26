using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VR.UGUI.FrameWork {
         public delegate void PointerEventHandler(PointerEventData eventData);
        public class UIEventListener : MonoBehaviour,IPointerDownHandler,IPointerClickHandler,IPointerUpHandler
            {

            public event PointerEventHandler PointerClick;
            public event PointerEventHandler PointerDown;
            public event PointerEventHandler PointerUp;

            public static UIEventListener GetListener(Transform tf)
            {
               UIEventListener uiEvent = tf.GetComponent<UIEventListener>();
               if (uiEvent == null) uiEvent = tf.gameObject.AddComponent<UIEventListener>();
               return uiEvent;

            }
        
                public void OnPointerDown(PointerEventData eventData)
                {
                    if (PointerDown!=null) PointerDown(eventData);
                }

                public void OnPointerClick(PointerEventData eventData)
                {
                    if (PointerClick != null) PointerClick(eventData);
                }

                public void OnPointerUp(PointerEventData eventData)
                {
                    if (PointerUp != null) PointerUp(eventData);
                }
            }
}
