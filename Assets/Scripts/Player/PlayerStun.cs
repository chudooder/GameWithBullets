using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerStun : MonoBehaviour
{
	public enum StackMode { None, Max, Add }
	public float stun;
	public float totalStun;
	private int unstunnable;

	void FixedUpdate() {
		if (stun > 0) {
			stun = Mathf.Max (stun - Time.deltaTime, 0);
			if (stun == 0) {
				unstun ();
			}
		}

	}

	public void Stun(float stun, StackMode stack = StackMode.None) {
		if (unstunnable > 0) {
			return;
		}
			
		if (this.stun > 0) {
			if (stack == StackMode.Max) {
				this.stun = Mathf.Max (this.stun, stun);
				this.totalStun = this.stun;
			} else if (stack == StackMode.Add) {
				this.stun += stun;
				this.totalStun = this.stun;
			}
		} else {
			this.stun = stun;
			this.totalStun = this.stun;
			GetComponent<PlayerMovement> ().MoveLocked = true;
			GetComponent<PlayerMovement> ().AimLocked = true;
		}
	}

	private void unstun() {
		this.totalStun = 0;
		GetComponent<PlayerMovement> ().MoveLocked = false;
		GetComponent<PlayerMovement> ().AimLocked = false;
	}

	public void PushUnstunnable(){
		unstunnable++;
	}

	public void PopUnstunnable(){
		unstunnable--;
	}

}

