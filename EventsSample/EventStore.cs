using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace EventsSample
{
	public class EventStore
	{
		public EventStore()
		{
			ConnectionString = "Server=DESKTOP-EHALUVC;Database=EventsSample;Trusted_Connection=True;MultipleActiveResultSets=true";
		}

		public string ConnectionString { get; }

		public IEnumerable<DomainEvent> GetAll(int division)
		{
			ICollection<DomainEvent> @events = new Collection<DomainEvent>();

			string commandText = "SELECT * FROM Events WHERE Division = @division";
			using (var connection = new SqlConnection(ConnectionString))
			{
				using (var command = connection.CreateCommand())
				{
					command.CommandText = commandText;

					var divisionSqlParameter = new SqlParameter("@division", SqlDbType.Int) {Value = division};
					command.Parameters.Add(divisionSqlParameter);

					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.HasRows && reader.Read())
					{
						string payload = reader["Payload"].ToString();
						string type = reader["Type"].ToString();
						Type type5 = Type.GetType(type, true, true);

						//var type = reader["Type"].ToString();
						//Type tt = Type.GetType(type, true);
						var @event = JsonConvert.DeserializeObject(payload, type5);
					}
				}
			}

			return @events;
		}


		public void Save(DomainEvent @event)
		{
			string commandText = "INSERT INTO Events (Id, Division, Payload, Type) Values (@Id, @Division, @Payload, @Type)";
			using (var connection = new SqlConnection(ConnectionString))
			{
				using (var command = connection.CreateCommand())
				{
					command.CommandText = commandText;

					var id = new SqlParameter("@Id", SqlDbType.UniqueIdentifier) {Value = @event.Id};
					var division = new SqlParameter("@Division", SqlDbType.Int) {Value = @event.Division};
					var payload = new SqlParameter("@Payload", SqlDbType.NVarChar) {Value = JsonConvert.SerializeObject(@event, new JsonSerializerSettings{TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full})};
					var type = new SqlParameter("@Type", SqlDbType.NVarChar) { Value = @event.GetType().FullName };

					command.Parameters.Add(id);
					command.Parameters.Add(division);
					command.Parameters.Add(payload);
					command.Parameters.Add(type);

					connection.Open();
					int res = command.ExecuteNonQuery();
				}
			}
		}
	}
}