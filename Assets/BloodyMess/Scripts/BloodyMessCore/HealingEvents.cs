
/////////////////////////////////////////////////////////////////////////////////////////
//This script initializes the Healing Event System and sends the events. Use another script 
//to activate the events(I wouldn't modify this scritp
//////////////////////////////////////////////////////////////////////////////////////////


using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//setup the Healing Events
public interface IHealingEventHandler : IEventSystemHandler {
	void AddHealth(float amount);
	void AddLimbHealth(float amount);
	void AddLimbHealthSelective(float amount, int limbID);

}



public class HealingEvents : MonoBehaviour {



	//send event from external script
	public void HealTotal(float amount, GameObject target) {

		ExecuteEvents.Execute<IHealingEventHandler>(target, null, (x,y)=>x.AddHealth(amount));


	}

	//send event from external script
	public void HealAllLimbs(float amount, GameObject target ) {

		ExecuteEvents.Execute<IHealingEventHandler>(target, null, (x,y)=>x.AddLimbHealth(amount));
	

	}

	//send event from external script
	public void HealSpecificLimb(float amount, int limbID, GameObject target) {

		ExecuteEvents.Execute<IHealingEventHandler>(target, null, (x,y)=>x.AddLimbHealthSelective(amount, limbID));

	}
}
