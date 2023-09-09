using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.StateMachine;
using DG.Tweening;
using System;

namespace Boss
{
    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK,
        DEATH
    }
    
    public class BossBase : MonoBehaviour
    {
        private StateMachine<BossAction> stateMachine;
        [Header("Animation")]
        public float startAnimationDuration = .5f;
        public Ease startAnimationEase = Ease.OutBack;

        [Header("Attack")]
        public int attackAmount = 5;
        public float timeBetweenAttacks = .5f;

        public Health health;
        public float speed = 10f;
        public List<Transform> waypoints;


        private void Awake()
        {
            Init();
            health.OnKill += OnBossKill;
            OnValidate();
        }
        private void OnValidate()
        {
            if (health == null) health = GetComponent<Health>();
            
        }
        private void Init()
        {
            stateMachine = new StateMachine<BossAction>();
            stateMachine.Init();

            stateMachine.RegisterState(BossAction.INIT, new BossStateInit());
            stateMachine.RegisterState(BossAction.WALK, new BossStateWalk());
            stateMachine.RegisterState(BossAction.ATTACK, new BossStateAttack());
            stateMachine.RegisterState(BossAction.DEATH, new BossStateKill());
        }
        private void OnBossKill(Health h)
        {

        }

        private void SwitchInit()
        {
            SwitchState(BossAction.INIT);
        }


        public void SwitchState(BossAction state)
        {
            stateMachine.SwitchState(state, this);
        }


        public void StartInitAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }


        public void GoToRandomPoint(Action onArrive = null)
        {
            StartCoroutine(GoToPointCoroutine(waypoints[UnityEngine.Random.Range(0, waypoints.Count)]));
        }


        IEnumerator GoToPointCoroutine(Transform t, Action onArrive = null)
        {
            while (Vector3.Distance(transform.position, t.position) > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
            }
            onArrive?.Invoke();
        }


        public void StartAttack(Action endCallback = null)
        {
            StartCoroutine(AttackCoroutine(endCallback));
        }

        IEnumerator AttackCoroutine(Action endCallback)
        {
            int attacks = 0;
            while(attacks < attackAmount)
            {
                attacks++;
                yield return new WaitForSeconds(timeBetweenAttacks);
            }
            endCallback.Invoke();
        }
    }
}
