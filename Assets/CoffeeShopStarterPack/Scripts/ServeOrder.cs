
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PW
{
    public class ServeOrder : MonoBehaviour
    {

        int order_count = 1;

        int total_order_served = 0;

        float totalServingTime;//Total serving time for order

        float curServeTime; //How much time left

        Image m_Image;//Image to hold product sprite.

        public int orderID;

        public Image serveTimeRepresentation;


        public void ServeMe()
        {
            var PlayerSlots = FindObjectOfType<PlayerSlots>();

            if (PlayerSlots != null)
            {
                
                if (!PlayerSlots.HoldsItem(orderID))
                {
                    return;
                }

                total_order_served++;

                Debug.Log("Served one thing");

                if (order_count == total_order_served)
                {
                    Debug.Log("customer is happy");
                    OrderCompleted();
                }
            }
        }

        public void OrderCompleted()
        {
            float success = curServeTime / totalServingTime;

            BasicGameEvents.RaiseOnOrderCompleted(orderID, success);
            StartCoroutine(DoEmphasize());
            
        }


        public IEnumerator DoEmphasize()
        {
            var outline = m_Image.GetComponent<Outline>();
            Color outlineColor = outline.effectColor;
            float totalTime = .6f;
            float curTime = totalTime;
            var alphaVal = 1f;
            while (curTime > 0)
            {
                curTime -= Time.deltaTime;

                transform.localScale += Vector3.one * 0.1f * -1f * Mathf.Sin(totalTime - 2 * curTime);
                //animate outline alpha
                alphaVal += 0.1f * -1f * Mathf.Sin(totalTime - 2 * curTime);
                outline.effectColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, alphaVal);
                yield return null;
            }
            transform.localScale = Vector3.one;
            outline.effectColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 0f);
            Destroy(gameObject);

        }

        public void SetOrder(int ID, float serveTime)
        {
            orderID = ID;
            totalServingTime = serveTime;
            curServeTime = totalServingTime;
            Invoke("CancelOrder", serveTime);
        }

        public void SetSprite(Sprite sprite)
        {

            m_Image = transform.GetChild(0).GetComponent<Image>();
            m_Image.sprite = sprite;
        }

        public void Update()
        {
            curServeTime -= Time.deltaTime;


            if (serveTimeRepresentation != null)
            {
                serveTimeRepresentation.fillAmount = curServeTime / totalServingTime;
            }
        }

        public void CancelOrder()
        {
            BasicGameEvents.RaiseOnOrderCancelled(orderID);
           
            Destroy(gameObject);


        }
    }
}