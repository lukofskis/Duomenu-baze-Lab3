namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

//using LateContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.LateContractsReport;
using SportoSalesReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSalesReport;
//using ServicesReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.ServicesReport;


/// <summary>
/// Database operations related to reports.
/// </summary>
public class AtaskaitaRepo
{

	// AND darbet >= IFNULL(?et, 0)
	//			WHERE
	//pare.pavadinimas = IFNULL(?par, pare.pavadinimas)
	public static List<SportoSalesReport.Ataskaita> GetContracts(int? sk, decimal? et, int? par, int? ski)
	{
		var query=
			$@"SELECT ALL
				pard.id_SPORTOSALE as idpard,
				mies.pavadinimas as miespav,
				UPPER(pard.pavadinimas) as pardpav,
				darb.etatas as darbet,
				IFNULL(pare.pavadinimas, '--Nera darbuotoju--') as parepav,
				IF(pare.pavadinimas IS NULL, 0, COUNT(*)) as skaicius,
				IF(pare.pavadinimas IS NULL, 0, MIN(darb.etatas)) as minetat,
				IF(pare.pavadinimas IS NULL, 0, MAX(darb.etatas)) as maxetat,
				IF(pare.pavadinimas IS NULL, 0, AVG(darb.etatas)) as videtat
			FROM
				`pareigos` pare INNER JOIN `darbuotojai` darb 
					ON pare.id_PAREIGA = darb.fk_PAREIGAid_PAREIGA 
				RIGHT JOIN `sportosales` pard 
					ON darb.fk_SPORTOSALEid_SPORTOSALE = pard.id_SPORTOSALE
				INNER JOIN `miestai` mies 
					ON mies.id_MIESTAS = pard.fk_MIESTASid_MIESTAS 
			WHERE pare.id_PAREIGA = IFNULL(?par, pare.id_PAREIGA) 
			GROUP BY
				mies.pavadinimas, pard.pavadinimas, pare.pavadinimas
			HAVING 
				skaicius >= IFNULL(?sk, skaicius)
				AND skaicius <= IFNULL(?ski, skaicius)
				AND videtat >= IFNULL(?et, videtat)
			ORDER BY
				pard.pavadinimas ASC, mies.pavadinimas ASC";
		var drc =
			Sql.Query(query, args => {
				args.Add("?sk", sk);
				args.Add("?et", et);
				args.Add("?par", par);
				args.Add("?ski", ski);
			});

		var result = 
			Sql.MapAll<SportoSalesReport.Ataskaita>(drc, (dre, t) => {
				t.ID = dre.From<int>("idpard");
				t.Miestas = dre.From<string>("miespav");
				t.Pavadinimas = dre.From<string>("pardpav");
				t.Pareigos = dre.From<string>("parepav");
				t.BendrasPareiguSkaicius = dre.From<int>("skaicius");
				t.MaziausiasPareigosEtatas = dre.From<decimal>("minetat");
				t.DidziausiasPareigosEtatas = dre.From<decimal>("maxetat");
				t.VidutinisPareigosEtatas = dre.From<decimal>("videtat");


			});

		return result;
	}

	public static List<SportoSalesReport.Pareiga> ListPareigos()
	{
		var query = $@"SELECT * FROM `pareigos`";

		var drc = Sql.Query(query);

		var results = Sql.MapAll<SportoSalesReport.Pareiga>(drc, (dre, bus) => {
			bus.Id = dre.From<int>("id_PAREIGA");
			bus.Pavadinimas = dre.From<string>("pavadinimas");
		});

		return results;
	}
}


