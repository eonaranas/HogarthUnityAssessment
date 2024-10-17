using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HogarthAssessmentTest {
	public class WeaponObject : MonoBehaviour {

		[SerializeField]
		private WeaponData _weaponData;
		IWeapon _weapon;

		public IWeapon Weapon { get { return _weapon; } }

		#region mono
		private void Start() {
			_weapon = new BasicGun();
			_weapon.InitializeStats(_weaponData);
		}
		#endregion
	}
}