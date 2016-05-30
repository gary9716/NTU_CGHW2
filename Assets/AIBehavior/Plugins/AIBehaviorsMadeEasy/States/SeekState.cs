using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using AIBehaviorEditor;
#endif


namespace AIBehavior
{
	public class SeekState : BaseState
	{
		public bool specifySeekTarget = false;
		public string seekItemsWithTag = "Untagged";
		public Transform seekTarget = null;

		public BaseState seekTargetReachedState;
		public BaseState noSeekTargetFoundState;
		public float distanceToTargetThreshold = 0.25f;
		private float sqrDistanceToTargetThreshold = 1.0f;

		public bool destroyTargetWhenReached = false;


		protected override void Init(AIBehaviors fsm)
		{
			sqrDistanceToTargetThreshold = GetSquareDistanceThreshold();
			fsm.PlayAudio();
		}


		protected override void StateEnded(AIBehaviors fsm)
		{
		}


		protected override bool Reason(AIBehaviors fsm)
		{
			if ( seekTarget == null )
			{
				GameObject[] seekObjects = GameObject.FindGameObjectsWithTag(seekItemsWithTag);
				Vector3 pos = fsm.transform.position;
				Vector3 diff;
				float nearestItem = Mathf.Infinity;

				if ( seekObjects == null )
				{
					fsm.ChangeActiveState(noSeekTargetFoundState);
				}

				foreach ( GameObject go in seekObjects )
				{
					Transform tfm = go.transform;
					float sqrMagnitude;

					diff = tfm.position - pos;
					sqrMagnitude = diff.sqrMagnitude;

					if ( sqrMagnitude < nearestItem )
					{
						seekTarget = tfm;
						nearestItem = sqrMagnitude;
					}
				}
			}
			else
			{
				float sqrDist = (fsm.transform.position - seekTarget.position).sqrMagnitude;

				if ( sqrDist < sqrDistanceToTargetThreshold )
				{
					if ( destroyTargetWhenReached )
					{
						Destroy(seekTarget.gameObject);
					}

					fsm.ChangeActiveState(seekTargetReachedState);
					return false;
				}
			}

			return true;
		}


		protected override void Action(AIBehaviors fsm)
		{
			if ( seekTarget != null )
			{
				fsm.MoveAgent(GetNextMovement(fsm), movementSpeed, rotationSpeed);
			}
		}


		public override Vector3 GetNextMovement (AIBehaviors fsm)
		{
			if ( seekTarget != null )
			{
				return seekTarget.position;
			}

			return base.GetNextMovement (fsm);
		}


		protected virtual float GetSquareDistanceThreshold ()
		{
			return distanceToTargetThreshold * distanceToTargetThreshold;
		}
		
		
		public override string DefaultDisplayName()
		{
			return "Seek";
		}


	#if UNITY_EDITOR
		// === Editor Methods === //

		public override void OnStateInspectorEnabled(SerializedObject m_ParentObject)
		{
		}


		protected override void DrawStateInspectorEditor(SerializedObject stateObject, AIBehaviors stateMachine)
		{
			SerializedProperty property;

			GUILayout.Label ("Seek Properties:", EditorStyles.boldLabel);
			
			GUILayout.BeginVertical(GUI.skin.box);

			property = stateObject.FindProperty("specifySeekTarget");
			EditorGUILayout.PropertyField(property);

			if ( property.boolValue )
			{
				property = stateObject.FindProperty("seekTarget");
				EditorGUILayout.PropertyField(property);
			}
			else
			{
				GUILayout.Label("Seek items with tag:");
				property = stateObject.FindProperty("seekItemsWithTag");
				property.stringValue = EditorGUILayout.TagField(property.stringValue);
			}

			EditorGUILayout.Separator();
			GUILayout.BeginHorizontal();
			{
				GUILayout.Label("Seek Target Reached Transition:");
				property = stateObject.FindProperty("seekTargetReachedState");
				property.objectReferenceValue = AIBehaviorsStatePopups.DrawEnabledStatePopup(stateMachine, property.objectReferenceValue as BaseState);
			}
			GUILayout.EndHorizontal();

			property = stateObject.FindProperty("distanceToTargetThreshold");
			float prevValue = property.floatValue;
			EditorGUILayout.PropertyField(property);

			if ( property.floatValue <= 0.0f )
				property.floatValue = prevValue;

			property = stateObject.FindProperty("destroyTargetWhenReached");
			EditorGUILayout.PropertyField(property);

			EditorGUILayout.Separator();
			GUILayout.BeginHorizontal();
			{
				GUILayout.Label("No Seek Target Transition:");
				property = stateObject.FindProperty("noSeekTargetFoundState");
				property.objectReferenceValue = AIBehaviorsStatePopups.DrawEnabledStatePopup(stateMachine, property.objectReferenceValue as BaseState);
			}
			GUILayout.EndHorizontal();

			GUILayout.EndVertical();

			stateObject.ApplyModifiedProperties();
		}
	#endif
	}
}