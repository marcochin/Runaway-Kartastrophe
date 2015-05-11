using UnityEngine;
using System.Collections;

public class CodeComparison : MonoBehaviour {

	public void enterCode(string buttonCodeName){

		//can only enter code if locked in and timer has started
		if(CodeSpawner.currentCodeSpawner.isTimerStart() && LockTouchScript.currentLockScript.isLocked()){
			string codeName = CodeSpawner.currentCodeSpawner.getCurrentCodeName ();

			if(buttonCodeName.Equals(codeName)){
				CodeSpawner.currentCodeSpawner.advanceToNextCode();
			} else {
				CodeSpawner.currentCodeSpawner.resetCodeContainer();
			}
		}
	}
}
