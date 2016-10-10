using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
	private float startup;
	private float cooldown;
	private float active;

	public void Fire (){
		if (cooldown == 0 && Fireable) {
			startup = this.MaxStartup;
			active = this.MaxStartup + this.MaxActive;
			cooldown = this.MaxStartup + this.MaxActive + this.MaxCooldown;
			OnFire ();
			Invoke ("Activate", this.MaxStartup);
			Invoke ("Deactivate", this.MaxStartup + this.MaxActive);
		}
	}

	public virtual void FixedUpdate(){
		startup = Mathf.Max (0, startup - Time.deltaTime);
		active = Mathf.Max (0, active - Time.deltaTime);
		cooldown = Mathf.Max (0, cooldown - Time.deltaTime);

		if (startup == 0 && active > 0) {
			ActiveUpdate ();
		}
	}

	/* How much startup is left on the weapon, normalizd between 0 and 1 */
	public float Startup {
		get { return MaxStartup != 0 ? startup / MaxStartup : 0; }
	}
	/* How much active is left on the weapon, normalized between 0 and 1 */
	public float Active {
		get { return MaxActive != 0 ? active / MaxActive: 0; }
	}
	/* How much cooldown is left on the weapon, normalized between 0 and 1 */
	public float Cooldown {
		get { return MaxCooldown != 0 ? cooldown / MaxCooldown: 0; }
	}


	public abstract string UIName { get; }
	protected abstract float MaxStartup{ get; }
	protected abstract float MaxActive{ get; }
	protected abstract float MaxCooldown{ get; }
	protected virtual bool Fireable{ get { return true; } }

	protected virtual void OnFire () { }
	protected abstract void Activate ();
	protected virtual void ActiveUpdate() { }
	protected virtual void Deactivate() { }
}
