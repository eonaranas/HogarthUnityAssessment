using HogarthAssessmentTest;

public class BasicBullet : IBullet {

	#region IBullet implementations
	public float BulletSpeed { get; set; }
	public float Damage { get; set; }

	public void InitializeStats(BulletData bulletData) {
		BulletSpeed = bulletData.bulletSpeed;
		Damage = bulletData.damage;
	}
	#endregion
}
