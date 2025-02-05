using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backtrack : MonoBehaviour
{
   public float trackDuration = 4f;
   public float positionRecordInterval = 0.1f;
   public KeyCode backtrackKey = KeyCode.X;

   private Queue<PositionRecord> positionHistory = new Queue<PositionRecord>();
   private Rigidbody2D playerRigidBody;
   private bool isBacktracking = false;

   void Start()
   {
      playerRigidBody = GetComponent<Rigidbody2D>();
      StartCoroutine(RecordPosition());
   }

   void Update()
   {
      if (Input.GetKeyDown(backtrackKey) && !isBacktracking)
      {
         StartCoroutine(ExecuteBacktrack());
      }
   }

   IEnumerator RecordPosition()
   {
      while (true)
      {
         if (!isBacktracking && (positionHistory.Count == 0 || positionHistory.Peek().position != transform.position))
         {
            positionHistory.Enqueue(new PositionRecord
            {
               position = transform.position,
               time = Time.time
            });
         }

         while (positionHistory.Count > 0 && positionHistory.Peek().time < Time.time - trackDuration)
         {
            positionHistory.Dequeue();
         }

         yield return new WaitForSeconds(positionRecordInterval);
      }
   }

   IEnumerator ExecuteBacktrack()
   {
      if (positionHistory.Count == 0) yield break;

      isBacktracking = true;
      playerRigidBody.velocity = Vector2.zero;
      playerRigidBody.isKinematic = true;

      Vector3 targetPosition = positionHistory.Peek().position;
      foreach (var record in positionHistory)
      {
         if (record.time >= Time.time - trackDuration)
         {
            targetPosition = record.position;
            break;
         }
      }

      transform.position = targetPosition;
      Debug.Log($"Backtracked to: {targetPosition}");

      yield return new WaitForSeconds(0.1f);

      playerRigidBody.isKinematic = false;
      isBacktracking = false;
   }

   private class PositionRecord
   {
      public Vector3 position;
      public float time;
   }
}