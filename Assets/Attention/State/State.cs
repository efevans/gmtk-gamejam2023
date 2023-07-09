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
		public virtual void DesireFulfilled() { }
		public virtual void OnGameStart() { }
    } 
}
