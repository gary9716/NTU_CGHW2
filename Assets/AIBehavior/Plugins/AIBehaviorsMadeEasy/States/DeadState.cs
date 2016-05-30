using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using AIBehaviorEditor;
#endif


namespace AIBehavior
{
	public class DeadState : BaseState
	{
		public float destroyAfterTime = 0.0f;

		private bool destroyThis = false;
		private float destroyTime = 0.0f;


		protected override void Init(AIBehaviors fsm)
		{
			fsm.PlayAudio();
			fsm.MoveAgent(fsm.transform, 0.0f, 0.0f);

			destroyThis = destroyAfterTime > 0.0f;
			destroyTime = Time.time + destroyAfterTime;
		}

		protected override void StateEnded(AIBehaviors fsm)
		{
		}

		protected override bool Reason(AIBehaviors fsm)
		{
			return true;
		}

		protected override void Action(AIBehaviors fsm)
		{
			if ( destroyThis && Time.time > destroyTime )
			{
				Destroy (fsm.gameObject);
			}
		}
		
		
		public override string DefaultDisplayName()
		{
			return "Dead";
		}


	#if UNITY_EDITOR
		// === Editor Methods === //

		public override void OnStateInspectorEnabled(SerializedObject m_ParentObject)
		{
		}


		protected override void DrawStateInspectorEditor(SerializedObject m_Object, AIBehaviors stateMachine)
		{
			GUILayout.Label ("Dead Properties:", EditorStyles.boldLabel);
			
			GUILayout.BeginVertical(GUI.skin.box);

			InspectorHelper.DrawInspector(m_Object);

			GUILayout.EndVertical();

			m_Object.ApplyModifiedProperties();
		}
	#endif
	}
}