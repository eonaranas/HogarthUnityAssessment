
namespace HogarthAssessmentTest {
	public interface IBullet {
		float BulletSpeed { get; set; }
		float Damage { get; set; }
		void InitializeStats(BulletData bulletData);
	}
}