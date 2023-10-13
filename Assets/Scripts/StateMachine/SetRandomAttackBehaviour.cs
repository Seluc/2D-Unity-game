using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomAttack : StateMachineBehaviour {
  public List<string> boolNames;
  public bool updateOnState;
  public bool updateOnStateMachine;
  public bool valueOnEnter, valueOnExit;

  private string boolName;

  private void Awake() {
    boolName = boolNames[0];
  }

  // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
  //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //{
  //    
  //}

  // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
  //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //{
  //    
  //}

  // OnStateExit is called before OnStateExit is called on any state inside this state machine
  //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //{
  //    
  //}

  // OnStateMove is called before OnStateMove is called on any state inside this state machine
  //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //{
  //    
  //}

  // OnStateIK is called before OnStateIK is called on any state inside this state machine
  //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  //{
  //    
  //}

  //OnStateMachineEnter is called when entering a state machine via its Entry Node
  override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash) {
    if(updateOnStateMachine && boolNames.Count > 0) {
      var num = Random.Range(0, boolNames.Count + 1);

      if(num < boolNames.Count) {
        boolName = boolNames[num];
        animator.SetBool(boolNames[num], valueOnEnter);
      }
    }
  }

  // OnStateMachineExit is called when exiting a state machine via its Exit Node
  override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
    animator.SetBool(boolName, valueOnExit);
  }
}
