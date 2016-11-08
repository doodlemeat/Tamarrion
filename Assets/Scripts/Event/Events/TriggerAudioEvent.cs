using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamarrion {
	public class TriggerAudioEvent : BaseEvent {
		public string audio;
		public AudioOptions options;

		public TriggerAudioEvent(string audio, AudioOptions options = default(AudioOptions)) {
			if(options != null) {
				options.clip = audio;
			}

			this.audio = audio;
			this.options = options;
		}
	}
}
