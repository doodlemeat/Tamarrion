using UnityEngine;
using System.Collections.Generic;
namespace Tamarrion {
	abstract public class WingProgressionBase : MonoBehaviour {
		public static WingProgressionBase instance;

		public float initTime = 0.2f;
		TopgunTimer initTimer = new TopgunTimer ();
		protected Dictionary<string, WingProgression> WingProgressions = new Dictionary<string, WingProgression> ();

		void Awake () {
			instance = this;
		}

		protected class WingProgression {
			public WingProgression () { }
			public Transform Trans;
			public Dictionary<string, bool> WingStates;
		}
		protected WingProgression currentProgression;

		public delegate void InitDone ();
		public event InitDone onInitDone;
		bool initDone = false;

		void Start () {
			initTimer.StartTimerBySeconds (initTime);
		}

		void Update () {
			if ( initDone )
				return;

			initTimer.Update ();
			if ( initTimer.IsComplete ) {
				initDone = true;

				Initialize ();
				if ( onInitDone != null )
					onInitDone ();
			}
		}

		protected abstract void Initialize ();
		public abstract void UpdateWingState ();

		public bool GetWingProgStateByProgName (string p_name, string p_state) {
			bool progFound = false;
			foreach ( KeyValuePair<string, WingProgression> WingProgPair in WingProgressions ) {
				if ( WingProgPair.Key == p_name ) {
					progFound = true;
					if ( WingProgPair.Value.WingStates.ContainsKey (p_state) ) {
						return WingProgPair.Value.WingStates[p_state];
					}
					Debug.Log ("state not found in " + p_name);
				}
			}

			if ( !progFound )
				Debug.Log ("prog not found");

			return false;
		}

		//* if error: writes debug log message and returns false
		public bool GetWingProgStateInCurrent (string p_state) {
			if ( currentProgression == null ) {
				Debug.Log ("current progression is not set");
				return false;
			}

			if ( currentProgression.WingStates.ContainsKey (p_state) ) {
				return currentProgression.WingStates[p_state];
			}

			Debug.Log ("state not found");
			return false;
		}

		public Transform GetProgTransformInCurrent () {
			if ( currentProgression != null )
				return currentProgression.Trans;

			Debug.Log ("transform is null");
			return null;
		}

		public Transform GetProgTransformByName (string p_name) {
			foreach ( KeyValuePair<string, WingProgression> WingProgPair in WingProgressions ) {
				if ( WingProgPair.Key == p_name )
					return WingProgPair.Value.Trans;
			}

			Debug.Log ("transform is null");
			return null;
		}

		public void SetCurrentWingProgression (string p_name) {
			foreach ( KeyValuePair<string, WingProgression> WingProgPair in WingProgressions ) {
				if ( WingProgPair.Key == p_name )
					currentProgression = WingProgPair.Value;
			}

			if ( currentProgression == null )
				Debug.Log ("didnt find current: " + p_name);
		}

		protected void AddWingProgression (string p_name, Transform p_trans, Dictionary<string, bool> p_wingStates) {
			if ( WingProgressions.ContainsKey (p_name) ) {
				Debug.Log ("key already in dictionary");
				return;
			}

			WingProgression wingProg = new WingProgression ();
			wingProg.Trans = p_trans;
			wingProg.WingStates = p_wingStates;

			WingProgressions.Add (p_name, wingProg);
		}
	}
}