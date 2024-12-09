
using UnityEngine;
using System.Collections;
namespace PW
{
    public class ProductGameObject : MonoBehaviour
    {
        const float totalTimeGoingToSlot = .4f;

        public GameObject serveAsDifferentGameObject;

        //Product orderID
        public int orderID;

        public bool AddToPlateBeforeServed;

        public Vector3 plateOffset;

        public bool RegenerateProduct = false;

        public virtual IEnumerator AnimateGoingToSlot()
        {
            if (serveAsDifferentGameObject != null)
            {

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }

                var go = Instantiate(serveAsDifferentGameObject, transform);
                go.transform.SetAsFirstSibling();
            }

            float curTime = totalTimeGoingToSlot;

            //Vector3 centerPos = Camera.main.ViewportToWorldPoint();
            //Vector3 totalDist = (centerPos - transform.position);

            while (curTime > 0)
            {
                float timePassed = Time.deltaTime;
                //transform.position += timePassed * totalDist / totalTimeGoingToSlot;
                curTime -= timePassed;
                yield return null;
            }

            yield return null;

        }

        public virtual bool CanGoPlayerSlot()
        {
            var PlayerSlots = FindObjectOfType<PlayerSlots>();
            if (PlayerSlots.CanHoldItem(orderID))
            {
                BasicGameEvents.RaiseOnProductAddedToSlot(orderID);
                return true;
            }
            else
                return false;
        }


        public virtual IEnumerator MoveToPlace(Vector3 targetPos)
        {

            float totalTime = 1f;
            float curTime = totalTime;
            var totalDist = (targetPos - transform.position);
            while (curTime > 0)
            {
                var timePassed = Time.deltaTime;
                transform.position += timePassed * totalDist / totalTime;
                curTime -= timePassed;
                yield return null;
            }

            transform.position = targetPos;
            yield return null;

        }

    }
}
