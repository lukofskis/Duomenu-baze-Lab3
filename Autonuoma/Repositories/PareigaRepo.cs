namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


/// <summary>
/// Database operations related to 'Pareiga' entity.
/// </summary>
public class PareigaRepo
{
	public static List<Pareiga> List()
	{
		var query = $@"SELECT * FROM `pareigos` ORDER BY id_PAREIGA ASC";
		var drc = Sql.Query(query);

		var result =
		  Sql.MapAll<Pareiga>(drc, (dre, t) =>
		  {
			  t.Pavadinimas = dre.From<string>("pavadinimas");
			  t.Valandinis = dre.From<decimal>("valandinis");
			  t.id_Pareiga = dre.From<int>("id_PAREIGA");
		  });

		return result;
	}

	public static Pareiga Find(int id)
	{
		var query = $@"SELECT * FROM `pareigos` WHERE id_PAREIGA=?id";

		var drc =
		  Sql.Query(query, args =>
		  {
			  args.Add("?id", id);
		  });

		if (drc.Count > 0)
		{
			var result =
			  Sql.MapOne<Pareiga>(drc, (dre, t) =>
			  {
				  t.Pavadinimas = dre.From<string>("pavadinimas");
				  t.Valandinis = dre.From<decimal>("valandinis");
				  t.id_Pareiga = dre.From<int>("id_PAREIGA");
			  });

			return result;
		}

		return null;
	}

	public static void Insert(Pareiga artist)
	{
		var query =
		  $@"INSERT INTO `pareigos`
			(
				pavadinimas,
				valandinis,
				id_PAREIGA
			)
			VALUES(
				?pavadinimas,
				?valandinis,
				?id_PAREIGA
			)";

		Sql.Insert(query, args =>
		{
			args.Add("?pavadinimas", artist.Pavadinimas);
			args.Add("?valandinis", artist.Valandinis);
			args.Add("?id_PAREIGA", artist.id_Pareiga);
		});
	}

	public static void Update(Pareiga artist)
	{
		var query =
		  $@"UPDATE `pareigos`
			SET
				pavadinimas=?pavadinimas,
				valandinis=?valandinis
			WHERE
				id_PAREIGA=?id_PAREIGA";

		Sql.Update(query, args =>
		{
			args.Add("?pavadinimas", artist.Pavadinimas);
			args.Add("?valandinis", artist.Valandinis);
			args.Add("?id_PAREIGA", artist.id_Pareiga);
		});
	}

	public static void Delete(int id)
	{
		var query = $@"DELETE FROM `pareigos` WHERE id_PAREIGA=?id";
		Sql.Delete(query, args =>
		{
			args.Add("?id", id);
		});
	}
}
