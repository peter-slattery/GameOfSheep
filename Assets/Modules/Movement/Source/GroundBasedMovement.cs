using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Movement {
	public class GroundBasedMovement : MonoBehaviour {

		private bool m_Constructed = false;

		ITargetsMovable m_Targets;

		public void Construct () {
			if (m_Constructed)
				return;

			IFacadeBase facade = GetComponent<IFacadeBase> ();
			if (facade != null) {
				TargetsBase targets = facade.Targets;
				if (targets is ITargetsMovable) {
					m_Targets = targets as ITargetsMovable;

					m_Targets.MovementTarget = transform.position;
				}
			}
			m_Constructed = true;
		}

		void Start () {
			Construct ();
		}

		void Update () {
			if (m_Targets != null) {
				RaycastHit hitOnPathToTarget;
				Vector3 targetEvaluated;

				bool collided = RaycastToTarget (out targetEvaluated, out hitOnPathToTarget);

				if (collided) {
					Debug.Log ("Collided");
					targetEvaluated = EvaluateForSlope (m_Targets.MovementTarget, hitOnPathToTarget);
				}

				targetEvaluated = RaycastToGround (targetEvaluated);

				transform.position = targetEvaluated;
				m_Targets.MovementTarget = targetEvaluated;
			}
		}

		public bool RaycastToTarget (out Vector3 result, out RaycastHit hit) {
			Vector3 toTarget = m_Targets.MovementTarget - transform.position;
			Ray castForward = new Ray (transform.position, toTarget.normalized);

			if (Physics.Raycast (castForward, out hit, toTarget.magnitude)) {
				result = hit.point;
				return true;
			}

			result = m_Targets.MovementTarget;
			return false;
		}

		public Vector3 EvaluateForSlope (Vector3 originalTarget, RaycastHit hit) {
			Vector3 desiredDir = (originalTarget - transform.position); // Translate to Object Space
			Vector3 collisionRight = Vector3.Cross (desiredDir.normalized, hit.normal.normalized);
			Vector3 slopeDir = Vector3.Cross (hit.normal, collisionRight).normalized;

			Debug.DrawRay (hit.point, slopeDir * desiredDir.magnitude, Color.red, 5);

			return hit.point + (slopeDir * desiredDir.magnitude); // Translate back to World Space
		}

		public Vector3 RaycastToGround (Vector3 target) {
			Ray castAgainstGround = new Ray (target + Vector3.up * .1f, Vector3.down);
			RaycastHit hit;

			Debug.DrawRay (castAgainstGround.origin, castAgainstGround.direction * 5, Color.green, 5);
			if (Physics.Raycast (castAgainstGround, out hit)) {
				return hit.point;
			}
			return target;
		}
	}
}