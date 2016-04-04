using UnityEngine;

namespace L4ZR.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(CharacterController))]
    public class ZombieController : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public CharacterController character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<CharacterController>();
            target = GameObject.FindWithTag("Player").transform;
            agent.updateRotation = false;
            agent.updatePosition = true;
        }

        private void Awake()
        {
            
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);
            else
                target = GameObject.FindWithTag("Player").transform;

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
