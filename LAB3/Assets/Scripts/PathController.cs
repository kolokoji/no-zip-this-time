using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField]
    public PathManager pathManager;

    List<Waypoint> thePath;
    Waypoint target;
    public float MoveSpeed;
    public float RotateSpeed;
    public Animator animator;
    bool IsSprining;
    void Start()
    {
        IsSprining = false;
        animator.SetBool("IsSprining", IsSprining);



        thePath = pathManager.GetPath();
        if (thePath != null && thePath.Count > 0 )
        {
            target = thePath[0];
        }
    }

    void rotateTowardsTarget()
    {
        float stepSize = RotateSpeed * Time.deltaTime;

        Vector3 targetDir = target.pos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize,0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void moveForward()
    {
        float stepSize = Time.deltaTime * MoveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if (distanceToTarget < stepSize) {

            return;


        }
        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);
    }










    private void Update()
    {
        if(Input.anyKeyDown)
        {
            IsSprining = !IsSprining;
            animator.SetBool("IsSprining", IsSprining);

        }
        if(IsSprining)
        {
            rotateTowardsTarget();
            moveForward();

        }

      
    }

    private void OnTriggerEnter(Collider other)
    {
        target = pathManager.GetNextTarget();
    }



}
