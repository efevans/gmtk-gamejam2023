using FrugalTime.Playable;

namespace FrugalTime.Tick
{
    public abstract class State
	{
		protected Attention _attention;

		protected State(Attention attention)
		{
			_attention = attention;
		}

		public virtual void Start() { }
		public virtual void Tick(float delta) { }
		public virtual void VideoShown(Video video) { }
		public virtual void OnGameStart() { }
    } 
}
