using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using AIBehaviorEditor;
#endif


namespace AIBehavior
{
	public class FleeState : BaseState
	{
		public float startFleeDistance = 5.0f;

		public FleeMode fleeMode = FleeMode.AwayFromNearestPlayer;
		public string fleeTargetTag = "Untagged";
		public Transform fleeToTarget;
		public Vector3 fleeDirection;
		public float directionSeekDistance = 1.0f;
		private Transform currentTarget;

		public BaseState fleeTargetReachedState;
		public float distanceToTargetThreshold = 1.0f;
		private float sqrDistanceToTargetThreshold = 1.0f;

		private GameObject[] fleeToObjects = null;


		public enum FleeMode
		{
			NearestTaggedObject,
			FixedTarget,
			Direction,
			AwayFromNearestPlayer
		}


		protected override void Init(AIBehaviors fsm)
		{
			sqrDistanceToTargetThreshold = distanceToTargetThreshold * distanceToTargetThreshold;
			fsm.PlayAudio();
			fleeToObjects = GameObject.FindGameObjectsWithTag(fleeTargetTag);
		}

		protected override void StateEnded(AIBehaviors fsm) {}

		protected override bool Reason(AIBehaviors fsm)
		{
			if ( currentTarget != null )
			{
				float sqrDist = (fsm.transform.position - currentTarget.position).sqrMagnitude;

				if ( sqrDist < sqrDistanceToTargetThreshold )
				{
					fsm.ChangeActiveState(fleeTargetReachedState);
					return false;
				}
			}

			return true;
		}


		protected override void Action(AIBehaviors fsm)
		{
			fsm.MoveAgent(GetNextMovement(fsm), movementSpeed, rotationSpeed);
		}


		public override Vector3 GetNextMovement (AIBehaviors fsm)
		{
			Vector3 result;

			switch ( fleeMode )
			{
			case FleeMode.FixedTarget:
				if ( fleeToTarget != null )
				{
					currentTarget = fleeToTarget;
					result = fleeToTarget.position;
				}
				else
				{
					Debug.LogWarning("Flee To Target isn't set for FleeState");
					result = base.GetNextMovement(fsm);
				}

				break;
				
			case FleeMode.NearestTaggedObject:
				float nearestSqrDistance = Mathf.Infinity;
				int targetIndex = -1;
				
				for ( int i = 0; i < fleeToObjects.Length; i++ )
				{
					Vector3 dist = fleeToObjects[i].transform.position - this.transform.position;
					
					if ( dist.sqrMagnitude < nearestSqrDistance )
					{
						nearestSqrDistance = dist.sqrMagnitude;
						targetIndex = i;
					}
				}
				
				if ( targetIndex != -1 )
				{
					currentTarget = fleeToObjects[targetIndex].transform;
					result = currentTarget.position;
				}
				else
				{
					result = base.GetNextMovement(fsm);
				}

				break;

			case FleeMode.Direction:
				result = fsm.transform.position + fleeDirection * directionSeekDistance;
				break;

			case FleeMode.AwayFromNearestPlayer:
				Vector3 nearestPlayerPosition = fsm.GetClosestPlayer(objectFinder.GetTransforms()).position;
				Vector3 fsmPosition = fsm.transform.position;
				Vector3 direction = (fsm.transform.position - nearestPlayerPosition).normalized * directionSeekDistance;
				
				result = fsmPosition + direction;
				break;

			default:
				result = base.GetNextMovement(fsm);
				break;
			}
			
			return result;
		}
		
		
		public override string DefaultDisplayName()
		{
			return "Flee";
		}


	#if UNITY_EDITOR
		// === Editor Methods === //

		public override void OnStateInspectorEnabled(SerializedObject m_ParentObject)
		{
		}


		protected override void DrawStateInspectorEditor(SerializedObject m_Object, AIBehaviors stateMachine)
		{
			SerializedObject m_State = new SerializedObject(this);
			SerializedProperty m_property;
			GUIContent directionSeekDistanceContent = new GUIContent("Direction Seek Distance", "This distance should be greater than the stopping distance of the Nav Mesh Agent. Default=1");

			m_State.Update();

			GUILayout.Label("Flee Properties:", EditorStyles.boldLabel);
			GUILayout.BeginVertical(GUI.skin.box);

			m_property = m_State.FindProperty("startFleeDistance");
			EditorGUILayout.PropertyField(m_property);

			EditorGUILayout.Separator();
			GUILayout.Label("Flee to target:", EditorStyles.boldLabel);

			m_property = m_State.FindProperty("fleeMode");
			EditorGUILayout.PropertyField(m_property);

			FleeMode fleeMode = (FleeMode)m_property.enumValueIndex;

			switch ( fleeMode )
			{
			case FleeMode.NearestTaggedObject:
				EditorGUILayout.Separator();
				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("Use nearest object with tag:");

					m_property = m_State.FindProperty("fleeTargetTag");
					m_property.stringValue = EditorGUILayout.TagField(m_property.stringValue);
				}
				GUILayout.EndHorizontal();

				break;

			case FleeMode.FixedTarget:
				m_property = m_State.FindProperty("fleeToTarget");
				EditorGUILayout.PropertyField(m_property);

				break;
				
			case FleeMode.Direction:
				m_property = m_State.FindProperty("fleeDirection");
				EditorGUILayout.PropertyField(m_property);
				
				m_property = m_State.FindProperty("directionSeekDistance");
				EditorGUILayout.PropertyField(m_property, directionSeekDistanceContent);

				break;

			case FleeMode.AwayFromNearestPlayer:
				m_property = m_State.FindProperty("directionSeekDistance");
				EditorGUILayout.PropertyField(m_property, directionSeekDistanceContent);
				
				break;
			}

			EditorGUILayout.Separator();
			GUILayout.BeginHorizontal();
			{
				GUILayout.Label("Flee Target Reached Transition:");
				m_property = m_State.FindProperty("fleeTargetReachedState");
				m_property.objectReferenceValue = AIBehaviorsStatePopups.DrawEnabledStatePopup(stateMachine, m_property.objectReferenceValue as BaseState);
			}
			GUILayout.EndHorizontal();

			m_property = m_State.FindProperty("distanceToTargetThreshold");
			float prevValue = m_property.floatValue;
			EditorGUILayout.PropertyField(m_property);

			if ( m_property.floatValue <= 0.0f )
				m_property.floatValue = prevValue;

			GUILayout.EndVertical();

			m_State.ApplyModifiedProperties();
		}
	#endif
	}
}