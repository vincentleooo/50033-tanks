using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
	private bool wimpedOut = false;

	public override void Act(StateController controller)
	{
		Chase(controller);
	}

	private void Chase(StateController controller)
	{
		float criteria;
		if (wimpedOut)
		{
			criteria = 0.5f;
		}
		else
		{
			criteria = 0.3f;
		}
		if (Random.value < criteria) // Wimpy
		{
			Vector3 multiplier = new Vector3(Random.value, 1f, Random.value);
			controller.navMeshAgent.destination = Vector3.Scale(controller.chaseTarget.position, multiplier);
			wimpedOut = true;
		}
		else
		{

			controller.navMeshAgent.destination = controller.chaseTarget.position;
			wimpedOut = false;
		}
		Debug.Log(controller.navMeshAgent.destination);
		controller.navMeshAgent.isStopped = false;
	}

}