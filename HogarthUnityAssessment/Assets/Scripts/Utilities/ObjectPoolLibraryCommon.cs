using UnityEngine;

namespace AaronTools {

	public class ObjectPoolLibraryCommon : MonoSingleton<ObjectPoolLibraryCommon> {

        public enum PoolType { BULLET };

        public ObjectPoolManager[] objectPoolers;

		public ObjectPoolManager GetObjectPooler(PoolType poolerType) {
			if (objectPoolers == null || objectPoolers.Length <= 0)
				return null;
			return objectPoolers[(int)poolerType];
		}
	}
}