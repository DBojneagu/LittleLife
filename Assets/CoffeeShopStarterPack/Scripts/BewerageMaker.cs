
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PW
{
    [RequireComponent(typeof(Collider))]
    public class BewerageMaker : MonoBehaviour
    {
        [SerializeField]
        public bool useAnimation = true;

        [SerializeField]
        public bool useTweeningAnimation = false;

        //Animation state for prefill
        public string preFillAnimationStateName;

        //time takes to prefill
        public float preFillProcess;

        //Animation ending state for fillEnded.
        public string fillEndedAnimationState;

        //time takes to fill the cup with particle.
        public float fillingProcess;

        [SerializeField]
        public Transform dummyAnimationTarget;
        //optional particle system to show drink getting filled.
        [SerializeField]
        public ParticleSystem fillParticle;

        [SerializeField]
        public Transform finalTweenTarget;


        public GameObject cupType;

        //UI indicator to show progress
        public GameObject progressHelperprefab;

        //the position where the cup will be placed on instantiate
        public Transform fillCupSpot;


        private float totalProcess;

        bool canFillCup = true;

        FillCupHelper fillCupHelper;

        ProgressHelper m_progressHelper;

        Collider m_Collider;

        Animator m_animator;
        
        void Start()
        {
            
            totalProcess = preFillProcess + fillingProcess;

            
            if (progressHelperprefab != null)
            {
                m_progressHelper = Instantiate(progressHelperprefab, transform).GetComponent<ProgressHelper>();

                m_progressHelper.ToggleHelper(false);
            }

            
            m_Collider = GetComponent<Collider>();

            m_Collider.enabled = true;

            
            if (dummyAnimationTarget != null)
                m_animator = dummyAnimationTarget.GetComponent<Animator>();

         
            if (useTweeningAnimation)
            {
                if(m_animator!=null)
                    m_animator.enabled = false;
            }
                
        }

        void OnMouseUp()
        {
            if (canFillCup)
            {
                StartFillingStep();
            }
        }

        void StartFillingStep()
        {
            canFillCup = false;

           
            SetTheCup();

            if(m_progressHelper!=null)
                m_progressHelper.ToggleHelper(true);

            if (!string.IsNullOrEmpty(preFillAnimationStateName) || useTweeningAnimation)
            {
                StartPreFillAnimationState();
            }
            else
            {
                StartCoroutine(DoFillAnimation());

            }
        }

        void StartPreFillAnimationState()
        {
            if (!useTweeningAnimation)
            {
                if (m_animator != null)
                {
                    m_animator.SetTrigger(preFillAnimationStateName);
                }

            }
                StartCoroutine(DoPreFill(dummyAnimationTarget, finalTweenTarget));
        }

        IEnumerator DoPreFill(Transform target, Transform finalTweenValue)
        {

            float curPreFill = preFillProcess;
            Vector3 totalDist = Vector3.zero;
            Vector3 totalRot = Vector3.zero;
            Vector3 FinalPosition;
            Vector3 FinalRotation;

            if (finalTweenTarget != null && target != null)
            {
                FinalPosition = finalTweenValue.position;
                FinalRotation = finalTweenValue.rotation.eulerAngles;
                totalDist = (FinalPosition - target.transform.position);
                totalRot = (FinalRotation - target.transform.rotation.eulerAngles);
            }
            while (curPreFill > 0)
            {
                if (useTweeningAnimation)
                {
                    target.transform.position += (Time.deltaTime * totalDist) / preFillProcess;
                    target.transform.rotation = Quaternion.Euler(target.transform.rotation.eulerAngles + (Time.deltaTime * totalRot) / preFillProcess);
                }

                curPreFill -= Time.deltaTime;

                var now = preFillProcess - curPreFill;
                m_progressHelper.UpdateProcessUI(now, totalProcess);

                yield return null;
            }

            StartCoroutine(DoFillAnimation());
        }

        IEnumerator DoFillAnimation()
        {
            if (!useTweeningAnimation && (string.IsNullOrEmpty(fillEndedAnimationState) || fillingProcess < 0.001f))
            {
                fillCupHelper.DoFill(0f);
            }
            else
            {

                fillCupHelper.DoFill(fillingProcess);

                if (fillParticle != null)
                    fillParticle.Play();
                float fillCurrent = fillingProcess;

                while (fillCurrent > 0)
                {

                    fillCurrent -= Time.deltaTime;

                    var valNow = preFillProcess + fillingProcess - fillCurrent;

                    if (m_progressHelper != null)
                        m_progressHelper.UpdateProcessUI(valNow, totalProcess);

                    yield return null;
                }

            }

            OnFillEnded();

        }



        void OnFillEnded()
        {
            if(m_progressHelper!=null)
                m_progressHelper.ToggleHelper(false);

            m_Collider.enabled = false;

            fillCupHelper.FillEnded();

            if (fillParticle != null)
            {
                fillParticle.Stop();
            }

            StartCoroutine(DoFillEnded());

        }

        
        void SetTheCup()
        {
            GameObject cup = Instantiate(cupType, fillCupSpot);

            fillCupHelper = cup.GetComponent<FillCupHelper>();

            fillCupHelper.SetMachine(this);

            if(m_progressHelper!=null)
                m_progressHelper.ToggleHelper(true);

        }

        public void UnSetTheCup()
        {
            canFillCup = true;

            fillCupHelper = null;

            m_Collider.enabled = true;
        }

        IEnumerator DoFillEnded()
        {
            if (m_animator != null && !string.IsNullOrEmpty(fillEndedAnimationState))
                m_animator.SetTrigger(fillEndedAnimationState);
            Vector3 totalDist = Vector3.zero;
            Vector3 totalRot = Vector3.zero;
            Vector3 FinalPosition;
            Vector3 FinalRotation;
            if (useTweeningAnimation)
            {

                float reverseMove = preFillProcess;
                if (dummyAnimationTarget != null && finalTweenTarget != null)
                {
                     FinalPosition = transform.position;
                     FinalRotation = transform.rotation.eulerAngles;
                     totalDist = (FinalPosition - dummyAnimationTarget.transform.position);
                     totalRot = (FinalRotation - dummyAnimationTarget.transform.rotation.eulerAngles);
                }

                while (reverseMove > 0)
                {
                    if (useTweeningAnimation)
                    {
                        dummyAnimationTarget.transform.position += (Time.deltaTime * totalDist) / preFillProcess;
                        dummyAnimationTarget.transform.rotation = Quaternion.Euler(dummyAnimationTarget.transform.rotation.eulerAngles + (Time.deltaTime * totalRot) / preFillProcess);
                        

                    }
                    reverseMove -= Time.deltaTime;
                    yield return null;
                }
                if (dummyAnimationTarget != null)
                {
                    dummyAnimationTarget.localPosition = Vector3.zero;
                    dummyAnimationTarget.transform.localRotation = Quaternion.identity;
                }
                
            }

            yield return null;
        }

    }
}