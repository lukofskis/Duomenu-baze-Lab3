namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;

public class MiestasRepo
{
	public static List<Miestas> List()
	{
		string query = $@"SELECT * FROM `miestai` ORDER BY id_MIESTAS ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<Miestas>(drc, (dre, t) =>
			{
				t.Pavadinimas = dre.From<string>("pavadinimas");
				t.Id = dre.From<int>("id_MIESTAS");
			});

		return result;
	}

	public static Miestas Find(int id)
	{
		var query = $@"SELECT * FROM `miestai` WHERE id_MIESTAS=?id_MIESTAS";
		var drc =
			Sql.Query(query, args =>
			{
				args.Add("?id_MIESTAS", id);
			});

		var result =
			Sql.MapOne<Miestas>(drc, (dre, t) =>
			{
				t.Id = dre.From<int>("id_MIESTAS");
				t.Pavadinimas = dre.From<string>("pavadinimas");
			});

		return result;
	}

	public static void Update(Miestas gamintojas)
	{
		var query =
			$@"UPDATE `miestai` 
			SET 
				pavadinimas=?pavadinimas 
			WHERE 
				id_MIESTAS=?id_MIESTAS";

		Sql.Update(query, args =>
		{
			args.Add("?pavadinimas", gamintojas.Pavadinimas);
			args.Add("?id_MIESTAS", gamintojas.Id);
		});
	}

	
	public static void Insert(Miestas gamintojas)
	{
		var query = $@"INSERT INTO `miestai` ( pavadinimas ) VALUES ( ?pavadinimas)";
		Sql.Insert(query, args =>
		{
			args.Add("?pavadinimas", gamintojas.Pavadinimas);
		});
	}

	public static void Delete(int id)
	{
		var query = $@"DELETE FROM `miestai` where id_MIESTAS=?id_MIESTAS";
		Sql.Delete(query, args =>
		{
			args.Add("?id_MIESTAS", id);
		});
	}
}

