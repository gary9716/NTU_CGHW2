using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CharacterSetup))]
public class CharacterSetupEditor : Editor {

	public override void OnInspectorGUI() {
		serializedObject.Update();
		CharacterSetup setup = (CharacterSetup)target;

		EditorGUILayout.HelpBox("General Setup", MessageType.None ,true);
		setup.characterName = EditorGUILayout.TextField("Character Name", setup.characterName);
		setup.loadPrevious = EditorGUILayout.Toggle("Load Saved", setup.loadPrevious);
		setup.target = (GameObject)EditorGUILayout.ObjectField("Script Target", setup.target, typeof(GameObject), true);
		EditorGUILayout.HelpBox("Leave target blank if your custom scripts accessing the Damage Event System are on this gameObject. Otherwise place the gameObject your custom scripts are on above.", MessageType.Warning ,true);
		setup.renderers = (GameObject)EditorGUILayout.ObjectField("Renderers Parent", setup.renderers, typeof(GameObject), true);
		setup.skeleton = (GameObject)EditorGUILayout.ObjectField("Skeleton Parent", setup.skeleton, typeof(GameObject), true);
		setup.usePooling = EditorGUILayout.Toggle("Use Pooling", setup.usePooling);
		if(!setup.usePooling) {
			setup.destroyTimer = EditorGUILayout.FloatField("Destruction Timer", setup.destroyTimer);
		}
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();

		EditorGUILayout.HelpBox("Ragdoll Setup", MessageType.None ,true);
		setup.useAutomaticRagdoll = EditorGUILayout.Toggle("Automatic Ragdoll?", setup.useAutomaticRagdoll);
		setup.ragdoll = (Transform )EditorGUILayout.ObjectField("Ragdoll", setup.ragdoll, typeof(Transform ), false);
		setup.ragdollWaitTime = EditorGUILayout.FloatField("Ragdoll Wait Time", setup.ragdollWaitTime);
		setup.destroyRagdolls = EditorGUILayout.Toggle("Destroy Ragdolls?", setup.destroyRagdolls);
		if (setup.destroyRagdolls) {
			setup.bodyStayTime = EditorGUILayout.FloatField("Ragdoll Stay Time", setup.bodyStayTime);
		}
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();




		EditorGUILayout.HelpBox("Health Setup", MessageType.None ,true);
		EditorGUILayout.LabelField("Current Health", setup.health.ToString());
		setup.maxHealth = EditorGUILayout.FloatField("Max Global Health", setup.maxHealth);
		setup.maxHeadHealth= EditorGUILayout.FloatField("Max Head Health", setup.maxHeadHealth);
		setup.maxRightHandHealth = EditorGUILayout.FloatField("Max Right Hand Health", setup.maxRightHandHealth);
		setup.maxLeftHandHealth = EditorGUILayout.FloatField("Max Left Hand Health", setup.maxLeftHandHealth);
		setup.maxRightLegHealth = EditorGUILayout.FloatField("Max Right Leg Health", setup.maxRightLegHealth);
		setup.maxLeftLegHealth = EditorGUILayout.FloatField("Max Left Leg Health", setup.maxLeftLegHealth);
		setup.maxRightUpperArmHealth = EditorGUILayout.FloatField("Max Right Upper Arm Health", setup.maxRightUpperArmHealth);
		setup.maxLeftUpperArmHealth = EditorGUILayout.FloatField("Max Left Upper Arm Health", setup.maxLeftUpperArmHealth);
		setup.maxRightForArmHealth = EditorGUILayout.FloatField("Max Right Forearm Health", setup.maxRightForArmHealth);
		setup.maxLeftForArmHealth = EditorGUILayout.FloatField("Max Left Forearm Health", setup.maxLeftForArmHealth);
		setup.maxExtra1Health = EditorGUILayout.FloatField("Max Extra Part 1 Health", setup.maxExtra1Health);
		setup.maxExtra2Health = EditorGUILayout.FloatField("Max Extra Part 2 Health", setup.maxExtra2Health);
		setup.maxExtra3Health = EditorGUILayout.FloatField("Max Extra Part 3 Health", setup.maxExtra3Health);
		setup.maxExtra4Health = EditorGUILayout.FloatField("Max Extra Part 4 Health", setup.maxExtra4Health);
		EditorGUILayout.HelpBox("If you set a body parts Max Health above Max Global Health (and dont set a higher damage multiplier) " +
			"you can make a body part not die even with useBodyDismemberment set to true!", MessageType.Info ,true);
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();

		EditorGUILayout.HelpBox("Damage Multiplier Setup", MessageType.None ,true);
		setup.criticalMultiplier = EditorGUILayout.FloatField("Critical Multiplier", setup.criticalMultiplier);
		setup.headMultiplier = EditorGUILayout.FloatField("Head Multiplier", setup.headMultiplier);
		setup.handMultiplier = EditorGUILayout.FloatField("Hand Multiplier", setup.handMultiplier);
		setup.armMultiplier = EditorGUILayout.FloatField("Arm Multiplier", setup.armMultiplier);
		setup.legMultiplier = EditorGUILayout.FloatField("Leg Multiplier", setup.legMultiplier);
		setup.bodyMultiplier = EditorGUILayout.FloatField("Body Multiplier", setup.bodyMultiplier);
		setup.extra1Multiplier = EditorGUILayout.FloatField("Extra Part 1 Multiplier", setup.extra1Multiplier);
		setup.extra2Multiplier = EditorGUILayout.FloatField("Extra Part 2 Multiplier", setup.extra2Multiplier);
		setup.extra3Multiplier = EditorGUILayout.FloatField("Extra Part 3 Multiplier", setup.extra3Multiplier);
		setup.extra4Multiplier = EditorGUILayout.FloatField("Extra Part 4 Multiplier", setup.extra4Multiplier);
		EditorGUILayout.HelpBox("If you set a body part's multiplier to zero it will not only apply no damage to it, " +
			"but will pass no damage onto the total health either. Only set a multiplier to zero if you are not using that limb.", MessageType.Warning ,true);
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();


		EditorGUILayout.HelpBox("Dismember Setup", MessageType.None ,true);
		setup.advancedRagdoll = EditorGUILayout.Toggle("Use Advanced Ragdoll", setup.advancedRagdoll);
		setup.useHeadDismember = EditorGUILayout.Toggle("Use Head Dismember?", setup.useHeadDismember);
		setup.useBodyDismember = EditorGUILayout.Toggle("Use Body Dismember?", setup.useBodyDismember);
		setup.useExplosion = EditorGUILayout.Toggle("Use Explosive Dismember?", setup.useExplosion);
		setup.weaponTypeForHead = EditorGUILayout.IntField("Weapon Type Head ", setup.weaponTypeForHead);
		setup.weaponTypeForLimbs = EditorGUILayout.IntField("Weapon Type Limb ", setup.weaponTypeForLimbs);
		setup.weaponTypeForBody = EditorGUILayout.IntField("Weapon Type Torso ", setup.weaponTypeForBody);
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();

		if (setup.useHeadDismember || setup.useBodyDismember) {
			EditorGUILayout.HelpBox("Body Parts To Spawn", MessageType.None ,true);
			if (setup.useHeadDismember) {
				setup.headModel = (Transform )EditorGUILayout.ObjectField("Head Model", setup.headModel, typeof(Transform ), false);
			}
			//Body parts to spawn when shot off
			if (setup.useBodyDismember) {
				setup.rightHandModel = (Transform )EditorGUILayout.ObjectField("Right Hand Model", setup.rightHandModel, typeof(Transform ), false);
				setup.leftHandModel = (Transform )EditorGUILayout.ObjectField("Left Hand Model", setup.leftHandModel, typeof(Transform ), false);
				setup.rightLegModel = (Transform )EditorGUILayout.ObjectField("Right Leg Model", setup.rightLegModel, typeof(Transform ), false);
				setup.leftLegModel = (Transform )EditorGUILayout.ObjectField("Left Leg Model", setup.leftLegModel, typeof(Transform ), false);
				setup.rightUpperArmModel = (Transform )EditorGUILayout.ObjectField("Right Upper Arm Model", setup.rightUpperArmModel, typeof(Transform ), false);
				setup.leftUpperArmModel = (Transform )EditorGUILayout.ObjectField("Left Upper Arm Model", setup.leftUpperArmModel, typeof(Transform ), false);
				setup.rightForArmModel = (Transform )EditorGUILayout.ObjectField("Right Forearm Model", setup.rightForArmModel, typeof(Transform ), false);
				setup.leftForArmModel = (Transform )EditorGUILayout.ObjectField("Left Forearm Model", setup.leftForArmModel, typeof(Transform ), false);
				setup.upperBodyModel = (Transform )EditorGUILayout.ObjectField("Upper Body Model", setup.upperBodyModel, typeof(Transform ), false);
				setup.extra1Model = (Transform )EditorGUILayout.ObjectField("Extra Part 1 Model", setup.extra1Model, typeof(Transform ), false);
				setup.extra2Model = (Transform )EditorGUILayout.ObjectField("Extra Part 2 Model", setup.extra2Model, typeof(Transform ), false);
				setup.extra3Model = (Transform )EditorGUILayout.ObjectField("Extra Part 3 Model", setup.extra3Model, typeof(Transform ), false);
				setup.extra4Model = (Transform )EditorGUILayout.ObjectField("Extra Part 4 Model", setup.extra4Model, typeof(Transform ), false);
				
				
				
			}
			EditorGUILayout.HelpBox("The above fields can be left blank if your model doesn't have the body part", MessageType.Info ,true);
		}
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();

		if (setup.useHeadDismember || setup.useBodyDismember) {
			EditorGUILayout.HelpBox("Body Part Skinned Meshes", MessageType.None ,true);

			if (setup.useHeadDismember) {



				EditorGUIUtility.labelWidth = 0;
				EditorGUIUtility.fieldWidth = 0;
				SerializedProperty head = serializedObject.FindProperty ("head");
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField(head, true);
				if(EditorGUI.EndChangeCheck())
					serializedObject.ApplyModifiedProperties();
				EditorGUIUtility.labelWidth = 25;
				EditorGUIUtility.fieldWidth = 50;
			}

			if (setup.useBodyDismember) {
				EditorGUIUtility.labelWidth = 0;
				EditorGUIUtility.fieldWidth = 0;
				SerializedProperty rightHands = serializedObject.FindProperty ("rightHands");
				SerializedProperty leftHands = serializedObject.FindProperty ("leftHands");
				SerializedProperty rightLegs = serializedObject.FindProperty ("rightLegs");
				SerializedProperty leftLegs = serializedObject.FindProperty ("leftLegs");
				SerializedProperty rightUpperArm = serializedObject.FindProperty ("rightUpperArm");
				SerializedProperty leftUpperArm = serializedObject.FindProperty ("leftUpperArm");
				SerializedProperty rightForeArm = serializedObject.FindProperty ("rightForArm");
				SerializedProperty leftForeArm = serializedObject.FindProperty ("leftForArm");
				SerializedProperty upperBody = serializedObject.FindProperty ("upperBody");
				SerializedProperty lowerBody = serializedObject.FindProperty ("lowerBody");
				SerializedProperty extra1 = serializedObject.FindProperty ("extra1");
				SerializedProperty extra2 = serializedObject.FindProperty ("extra2");
				SerializedProperty extra3 = serializedObject.FindProperty ("extra3");
				SerializedProperty extra4 = serializedObject.FindProperty ("extra4");
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField(rightHands, true);
				EditorGUILayout.PropertyField(leftHands, true);
				EditorGUILayout.PropertyField(rightLegs, true);
				EditorGUILayout.PropertyField(leftLegs, true);
				EditorGUILayout.PropertyField(rightUpperArm, true);
				EditorGUILayout.PropertyField(leftUpperArm, true);
				EditorGUILayout.PropertyField(rightForeArm, true);
				EditorGUILayout.PropertyField(leftForeArm, true);
				EditorGUILayout.PropertyField(upperBody, true);
				EditorGUILayout.PropertyField(lowerBody, true);
				EditorGUILayout.PropertyField(extra1, true);
				EditorGUILayout.PropertyField(extra2, true);
				EditorGUILayout.PropertyField(extra3, true);
				EditorGUILayout.PropertyField(extra4, true);
				if(EditorGUI.EndChangeCheck())
					serializedObject.ApplyModifiedProperties();
				EditorGUIUtility.labelWidth = 25;
				EditorGUIUtility.fieldWidth = 50;











			}
			EditorGUILayout.HelpBox("The above fields can be left blank if your model doesn't have the body part", MessageType.Info ,true);
		}
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();	


		if(setup.useExplosion) {
			EditorGUILayout.HelpBox("Objects(Parts) To Spawn On An Explosion", MessageType.None ,true);
			EditorGUIUtility.labelWidth = 0;
			EditorGUIUtility.fieldWidth = 0;
			SerializedProperty explosionParts = serializedObject.FindProperty ("explosionParts");
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField(explosionParts, true);
			if(EditorGUI.EndChangeCheck())
				serializedObject.ApplyModifiedProperties();
			EditorGUIUtility.labelWidth = 25;
			EditorGUIUtility.fieldWidth = 50;

		}
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		
		if (setup.useHeadDismember || setup.useBodyDismember) {

			

			EditorGUILayout.HelpBox("Body Part Colliders", MessageType.None ,true);
			if (setup.useHeadDismember) {
				EditorGUIUtility.labelWidth = 0;
				EditorGUIUtility.fieldWidth = 0;
				SerializedProperty headColliders = serializedObject.FindProperty ("headColliders");
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField(headColliders, true);
				if(EditorGUI.EndChangeCheck())
					serializedObject.ApplyModifiedProperties();
				EditorGUIUtility.labelWidth = 25;
				EditorGUIUtility.fieldWidth = 50;
			}
			if (setup.useBodyDismember) {
				EditorGUIUtility.labelWidth = 0;
				EditorGUIUtility.fieldWidth = 0;
				SerializedProperty rightHandColliders = serializedObject.FindProperty ("rightHandColliders");
				SerializedProperty leftHandColliders = serializedObject.FindProperty ("leftHandColliders");
				SerializedProperty rightLegColliders = serializedObject.FindProperty ("rightLegColliders");
				SerializedProperty leftLegColliders = serializedObject.FindProperty ("leftLegColliders");
				SerializedProperty rightUpperArmColliders = serializedObject.FindProperty ("rightUpperArmColliders");
				SerializedProperty leftUpperArmColliders = serializedObject.FindProperty ("leftUpperArmColliders");
				SerializedProperty rightForeArmColliders = serializedObject.FindProperty ("rightForArmColliders");
				SerializedProperty leftForeArmColliders = serializedObject.FindProperty ("leftForArmColliders");
				SerializedProperty upperBodyColliders = serializedObject.FindProperty ("upperBodyColliders");
				SerializedProperty lowerBodyColliders = serializedObject.FindProperty ("lowerBodyColliders");
				SerializedProperty extra1Colliders = serializedObject.FindProperty ("extra1Colliders");
				SerializedProperty extra2Colliders = serializedObject.FindProperty ("extra2Colliders");
				SerializedProperty extra3Colliders = serializedObject.FindProperty ("extra3Colliders");
				SerializedProperty extra4Colliders = serializedObject.FindProperty ("extra4Colliders");
				EditorGUI.BeginChangeCheck();
		
				EditorGUILayout.PropertyField(rightHandColliders, true);
				EditorGUILayout.PropertyField(leftHandColliders, true);
				EditorGUILayout.PropertyField(rightLegColliders, true);
				EditorGUILayout.PropertyField(leftLegColliders, true);
				EditorGUILayout.PropertyField(rightUpperArmColliders, true);
				EditorGUILayout.PropertyField(leftUpperArmColliders, true);
				EditorGUILayout.PropertyField(rightForeArmColliders, true);
				EditorGUILayout.PropertyField(leftForeArmColliders, true);
				EditorGUILayout.PropertyField(upperBodyColliders, true);
				EditorGUILayout.PropertyField(lowerBodyColliders, true);
				EditorGUILayout.PropertyField(extra1Colliders, true);
				EditorGUILayout.PropertyField(extra2Colliders, true);
				EditorGUILayout.PropertyField(extra3Colliders, true);
				EditorGUILayout.PropertyField(extra4Colliders, true);
				if(EditorGUI.EndChangeCheck())
					serializedObject.ApplyModifiedProperties();
				EditorGUIUtility.labelWidth = 25;
				EditorGUIUtility.fieldWidth = 50;
				EditorGUILayout.HelpBox("The above fields can be left blank if your model doesn't have the body part", MessageType.Info ,true);
			}
		}











	}
}

