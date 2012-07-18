using System;
using System.Configuration;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using Configuration = NHibernate.Cfg.Configuration;
using LightFarsiDic.Database.Base;
using LightFarsiDic.Database.Entities;

namespace LightFarsiDic.Database.Entities
{
	/// <summary>
	/// dicenfa NHibernate helper methods. This is suitable for windows-apps.
	/// </summary>
	public static class dicenfaSession
	{
		private static object _lock = new object();
		private static ISessionFactory _sessionFactory;

		private static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
				{
					lock (_lock)
					{
						var configuration = GetConfig();
						var mapping = GetMappings();
						configuration.AddDeserializedMapping(mapping, "NHSchema_dicenfa");
						_sessionFactory = configuration.BuildSessionFactory();
					}
				}
				return _sessionFactory;
			}
		}

		private static HbmMapping GetMappings()
		{
			var mapper = new ModelMapper();
			dicenfaMapper.MapToModel(mapper);
			dicenfaMapper.CustomMapToModel(mapper);

			var mapping = mapper.CompileMappingFor(
				new[]
					{
						typeof(EnglishToFarsi),
						typeof(FarsiToEnglish)
					});
			//Output XML mappings
			//Console.WriteLine(mapping.AsString());
			return mapping;
		}

		private static Configuration GetConfig()
		{
			var configure = new Configuration();
			configure.SessionFactoryName("SessionFactory_dicenfa");

			configure.DataBaseIntegration(
				db =>
				{
					db.ConnectionProvider<DriverConnectionProvider>();
					db.Dialect<SQLiteDialect>();
					db.Driver<SQLite20Driver>();
					db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
					db.IsolationLevel = IsolationLevel.ReadCommitted;
					db.ConnectionString = ConfigurationManager.ConnectionStrings["dicenfaConnectionString"].ConnectionString;
					db.Timeout = 15;

					////for testing ...
					//db.LogFormattedSql = true;
					//db.LogSqlInConsole = true;
				});
			return configure;
		}

		/// <summary>
		/// Create a database connection and open a ISession on it
		/// </summary>
		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}

		/// <summary>
		/// Create a database connection and open a ISession on it
		/// </summary>
		public static ISession OpenSession(FlushMode flushMode)
		{
			var session = SessionFactory.OpenSession();
			session.FlushMode = flushMode;
			return session;
		}

		/// <summary>
		/// Open a ISession on the given connection
		/// </summary>
		public static ISession OpenSession(IDbConnection conn)
		{
			return SessionFactory.OpenSession(conn);
		}

		/// <summary>
		/// Open a ISession on the given connection
		/// </summary>
		public static ISession OpenSession(IDbConnection conn, FlushMode flushMode)
		{
			var session = SessionFactory.OpenSession(conn);
			session.FlushMode = flushMode;
			return session;
		}

		/// <summary>
		/// Get a new stateless session.
		/// </summary>
		public static IStatelessSession OpenStatelessSession()
		{
			return SessionFactory.OpenStatelessSession();
		}

		/// <summary>
		/// Get a new stateless session for the given ADO.NET connection.
		/// </summary>
		public static IStatelessSession OpenStatelessSession(IDbConnection conn)
		{
			return SessionFactory.OpenStatelessSession(conn);
		}
	}
}
