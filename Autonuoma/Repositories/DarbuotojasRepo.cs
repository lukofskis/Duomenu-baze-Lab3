namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;

public class DarbuotojasRepo
{
	public static List<Darbuotojas> List()
	{
		string query = $@"SELECT * FROM `darbuotojai` ORDER BY asmens_kodas ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<Darbuotojas>(drc, (dre, t) =>
			{
				t.Vardas = dre.From<string>("vardas");
				t.Pavarde = dre.From<string>("pavarde");
				t.Asmens_kodas = dre.From<string>("asmens_kodas");

			});

		return result;
	}

	public static Darbuotojas Find(string id)
	{
		var query = $@"SELECT * FROM `darbuotojai` WHERE asmens_kodas=?asmens_kodas";
		var drc =
			Sql.Query(query, args =>
			{
				args.Add("?asmens_kodas", id);
			});

		var result =
			Sql.MapOne<Darbuotojas>(drc, (dre, t) =>
			{
				t.Vardas = dre.From<string>("vardas");
				t.Pavarde = dre.From<string>("pavarde");
				t.Asmens_kodas = dre.From<string>("asmens_kodas");
			});

		return result;
	}

	public static void Update(Darbuotojas gamintojas)
	{
		var query =
			$@"UPDATE `darbuotojai` 
			SET 
				vardas=?vardas 
				pavardež?pavarde
			WHERE 
				asmens_kodas=?asmens_kodas";

		Sql.Update(query, args =>
		{
			args.Add("?vardas", gamintojas.Vardas);
			args.Add("?pavarde", gamintojas.Pavarde);
			args.Add("?asmens_kodas", gamintojas.Asmens_kodas);
		});
	}

	public static void Insert(Darbuotojas gamintojas)
	{
		var query = $@"INSERT INTO `miestai` ( vardas, pavarde, asmens_kodas ) VALUES ( ?vardas, ?pavarde, ?asmens_kodas)";
		Sql.Insert(query, args =>
		{
			args.Add("?vardas", gamintojas.Vardas);
			args.Add("?pavarde", gamintojas.Pavarde);
			args.Add("?asmens_kodas", gamintojas.Asmens_kodas);
		});
	}

	public static void Delete(string id)
	{
		var query = $@"DELETE FROM `miestai` where asmens_kodas=?asmens_kodas";
		Sql.Delete(query, args =>
		{
			args.Add("?asmens_kodas", id);
		});
	}
}

