namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Newtonsoft.Json;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSaleF2;


/// <summary>
/// Database operations related to 'Parduotuve' entity.
/// </summary>
public class SportoSaleF2Repo
{
	public static List<ParduotuveF2L> ListParduotuves()
	{
		var query =
		  $@"SELECT
				p.id_SPORTOSALE,
				p.pavadinimas,
				p.adresas,
				p.patalpu_dydis
			FROM
				`sportosales` p

			ORDER BY p.id_SPORTOSALE ASC";

		var drc = Sql.Query(query);

		var result =
		  Sql.MapAll<ParduotuveF2L>(drc, (dre, t) =>
		  {
			  t.id_Product = dre.From<int>("id_SPORTOSALE");
			  t.Pavadinimas = dre.From<string>("pavadinimas");
			  t.Adresas = dre.From<string>("adresas");
			  t.Dydis = dre.From<double>("patalpu_dydis");

		  });

		return result;
	}

	public static ParduotuveF2CE FindParduotuvesCE(int id)
	{
		var query = $@"SELECT * FROM `sportosales` WHERE id_SPORTOSALE=?id";
		var drc =
		  Sql.Query(query, args =>
		  {
			  args.Add("?id", id);
		  });

		var result =
		  Sql.MapOne<ParduotuveF2CE>(drc, (dre, t) =>
		  {
			  //make a shortcut
			  var prod = t.Parduotuve;

			  prod.Pavadinimas = dre.From<string>("pavadinimas");
			  prod.Adresas = dre.From<string>("adresas");
			  prod.Dydis = dre.From<double>("patalpu_dydis");
			  prod.Id = dre.From<int>("id_SPORTOSALE");
			  prod.fk_Miestasid_Miestas = dre.From<int>("fk_MIESTASid_MIESTAS");
			  
		  });

		return result;
	}
	public static Darbuotojas FindWorker(string id)
	{
		var query = $@"SELECT * FROM `darbuotojai` WHERE asmens_kodas=?asmens_kodas";
		var drc =
		  Sql.Query(query, args =>
		  {
			  args.Add("?asmens_kodas", id);
		  });

		var result =
		  Sql.MapOne<Darbuotojas>(drc, (dre, prod) =>
		  {
			  //make a shortcut
			  prod.Vardas = dre.From<string>("vardas");
			  prod.Pavarde = dre.From<string>("pavarde");
			  prod.Asmens_kodas = dre.From<string>("asmens_kodas");


		  });

		return result;
	}

	public static int InsertParduotuve(ParduotuveF2CE prodCE)
	{
		var query =
		  $@"INSERT INTO `sportosales`
			(
				`pavadinimas`,
				`adresas`,
				`patalpu_dydis`,
				`id_SPORTOSALE`,
				`fk_MIESTASid_MIESTAS`
			)
			VALUES(
				?pavadinimas,
				?adresas,
				?patalpu_dydis,
				?id_SPORTOSALE,
				?fk_MIESTASid_MIESTAS
			)";

		var id =
		  Sql.Insert(query, args =>
		  {
			  //make a shortcut
			  var prod = prodCE.Parduotuve;

			  //
			  args.Add("?pavadinimas", prod.Pavadinimas);
			  args.Add("?adresas", prod.Adresas);
			  args.Add("?patalpu_dydis", prod.Dydis);
			  args.Add("?id_SPORTOSALE", prod.Id);
			  args.Add("?fk_MIESTASid_MIESTAS", prod.fk_Miestasid_Miestas);
		  });

		return (int)id;
	}

	public static void UpdateParduotuve(ParduotuveF2CE prodCE)
	{
		var query =
		  $@"UPDATE `sportosales`
			SET

				`pavadinimas` = ?pavadinimas,
				`adresas` = ?adresas,
				`patalpu_dydis` = ?patalpu_dydis,
				`fk_MIESTASid_MIESTAS` = ?fk_MIESTASid_MIESTAS

			WHERE id_SPORTOSALE=?id_SPORTOSALE";

		Sql.Update(query, args =>
		{
			//make a shortcut
			var prod = prodCE.Parduotuve;

			//
			args.Add("?pavadinimas", prod.Pavadinimas);
			args.Add("?adresas", prod.Adresas);
			args.Add("?patalpu_dydis", prod.Dydis);
			args.Add("?id_SPORTOSALE", prod.Id);
			args.Add("?fk_MIESTASid_MIESTAS", prod.fk_Miestasid_Miestas);
		});
	}

	public static void DeleteParduotuve(int id)
	{
		var query = $@"DELETE FROM `sportosales` where id_SPORTOSALE=?id_SPORTOSALE";
		Sql.Delete(query, args =>
		{
			args.Add("?id_SPORTOSALE", id);
		});
	}


	public static List<ParduotuveF2CE.DarbuotojasM> ListDarbuotojai(int pardId)
	{
		var query =
		  $@"SELECT *
			FROM `darbuotojai`
			WHERE fk_SPORTOSALEid_SPORTOSALE  = ?sportosaleId
			ORDER BY vardas ASC";

		var drc =
		  Sql.Query(query, args =>
		  {
			  args.Add("?sportosaleId", pardId);
		  });

		var result =
		  Sql.MapAll<ParduotuveF2CE.DarbuotojasM>(drc, (dre, t) =>
		  {
			  t.fk_PAREIGAid_PAREIGA = dre.From<int>("fk_PAREIGAid_PAREIGA");
			  t.Vardas = dre.From<string>("vardas");
			  t.Pavarde = dre.From<string>("pavarde");
			  t.Asmens_kodas = dre.From<string>("asmens_kodas");
			  t.Etatas = dre.From<decimal>("etatas");
		  });

		for (int i = 0; i < result.Count; i++)
			result[i].InListId = i;

		return result;
	}

	public static void InsertDarbuotojai(int pardId, ParduotuveF2CE.DarbuotojasM up)
	{
		var query =
		  $@"INSERT INTO `darbuotojai`
				(
					vardas,
					pavarde,
					asmens_kodas,
					etatas,
					fk_PAREIGAid_PAREIGA,
					fk_SPORTOSALEid_SPORTOSALE 
				)
				VALUES(
					?vardas,
					?pavarde,
					?asmens_kodas,
					?etatas,
					?fk_PAREIGAid_PAREIGA,
					?fk_SPORTOSALEid_SPORTOSALE 
				)";

		Sql.Insert(query, args =>
		{
			args.Add("?vardas", up.Vardas);
			args.Add("?pavarde", up.Pavarde);
			args.Add("?asmens_kodas", up.Asmens_kodas);
			args.Add("?etatas", up.Etatas);
			args.Add("?fk_PAREIGAid_PAREIGA", up.fk_PAREIGAid_PAREIGA);
			args.Add("?fk_SPORTOSALEid_SPORTOSALE", pardId);
		});
	}

	public static void DeleteDarbuotojaiParduotuveje(int product)
	{
		var query =
		  $@"DELETE FROM a
			USING `darbuotojai` as a
			WHERE a.fk_SPORTOSALEid_SPORTOSALE =?fk_SPORTOSALEid_SPORTOSALE";

		Sql.Delete(query, args =>
		{
			args.Add("?fk_SPORTOSALEid_SPORTOSALE", product);
		});
	}
}