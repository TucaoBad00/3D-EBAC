using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animation;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageble
    {

        public AnimationManager animationManager;
        public float startLife = 10f;
        public FlashColor flashColor;
        [SerializeField]private float _currentLife;

        private void Awake()
        {
            Init();
        }
        protected virtual void Init()
        {
            _currentLife = startLife;

        }
        protected virtual void Kill()
        {
            OnKill();
        }
        protected virtual void OnKill()
        {
            Destroy(gameObject,3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
        }
        public void OnDamage(float f)
        {
            if(flashColor != null)
            {
                flashColor.Flash();
            }
            _currentLife -= f;
            if(_currentLife <= 0)
            {
                Kill();
            }
        }
        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            animationManager.PlayAnimationByTrigger(animationType);
        }

        public void IDamage(float damage)
        {
            OnDamage(damage);
        }
        public void OnCollisionEnter(Collision collision)
        {
            Health p = collision.transform.GetComponent<Health>();
            if(p != null)
            {
                p.IDamage(1);
            }
        }
    }
}