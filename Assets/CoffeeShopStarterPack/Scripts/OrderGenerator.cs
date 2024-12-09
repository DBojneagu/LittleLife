
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace PW
{
    public class OrderGenerator : MonoBehaviour
    {
        public int MaxConcurrentOrder=4;

        public int currentOrderCount;

        public Sprite[] orderSprites;

        [HideInInspector]
        public int[] orderedProducts;

        public Transform UIParentForOrders;

        public GameObject orderRepPrefab;//The general prefab for order represantation

        private void OnEnable()
        {
            BasicGameEvents.onOrderCancelled += BasicGameEvents_onOrderCancelled;
            BasicGameEvents.onOrderCompleted += BasicGameEvents_onOrderCompleted;

        }
        private void OnDisable()
        {
            //Don't forget to remove listeners from events on disable.
            BasicGameEvents.onOrderCancelled -= BasicGameEvents_onOrderCancelled;
            BasicGameEvents.onOrderCompleted -= BasicGameEvents_onOrderCompleted;

        }

        private void BasicGameEvents_onOrderCancelled(int ID)
        {
            currentOrderCount--;

        }

        private void BasicGameEvents_onOrderCompleted(int ID,float percentageSucccess)
        {
            currentOrderCount--;
          
        }


        void Start()
        {
            StartCoroutine(GenerateOrderRoutine(3f));

        }


        public IEnumerator GenerateOrderRoutine(float intervalTime)
        {
            
            while (true)
            {
                if (currentOrderCount < MaxConcurrentOrder)
                {
                    GenerateOrder();
                    yield return new WaitForSeconds(intervalTime);
                }
                else
                {
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        public void GenerateOrder()
        {


            int spriteIndex = Random.Range(0, orderSprites.Length);

            int orderID = orderedProducts[spriteIndex];

            var newOrder = GameObject.Instantiate(orderRepPrefab, UIParentForOrders).GetComponent<ServeOrder>();

            newOrder.SetOrder(orderID,Random.Range(5f,40f));

            newOrder.SetSprite(orderSprites[spriteIndex]);

            currentOrderCount++;

        }

        public Sprite GetSpriteForOrder(int orderID)
        {
            var spriteIndex = Array.IndexOf(orderedProducts, orderID);
            if (spriteIndex<0)
                return null;
            return orderSprites[spriteIndex];
        }
    }
}