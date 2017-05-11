using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionBrain.Graphics
{
	public abstract class ManagerView : IDisposable
	{
		public Camera Camera { get; set; }
		public delegate void EventBody(BaseModel body);
		public event EventBody AddListenerOnPrevLoopBody;
		public event EventBody AddListenerOnPostLoopBody;
		List<BaseModel> BodyList { get; set; }

		public ManagerView()
		{
			BodyList = new List<BaseModel>();
			Camera = new Camera();
		}
		public bool Add(BaseModel baseModel)
		{
			return false;
		}
		public bool Remove()
		{
			return false;
		}
		public ManagerView Clear()
		{
			BodyList.Clear();
			return this;
		}
		public void Render()
		{
			for (int i = 0; i < BodyList.Count; i++)
			{
				BaseModel body = BodyList[i];

				if (AddListenerOnPrevLoopBody != null)
					AddListenerOnPrevLoopBody(body);

				// Update and Render

				if (AddListenerOnPostLoopBody != null)
					AddListenerOnPostLoopBody(body);
			}
		}

		public void Dispose()
		{
			Clear();
		}
	}
}
