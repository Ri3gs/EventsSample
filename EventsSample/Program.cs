using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var store = new EventStore();
			var @event = new AgreedOnTermsEvent(Guid.NewGuid(), 21, "sample", "email", "iban");

			//var type = @event.GetType();
			store.Save(@event);

			var @events = store.GetAll(21);
		}
	}
}
