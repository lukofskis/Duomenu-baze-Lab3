namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSalesReport;
using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

//using LateContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.LateContractsReport;
using SportoSalesReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSalesReport;
//using ServicesReport = Org.Ktu.Isk.P175B602.Autonuoma.Models.ServicesReport;
//using global::Autonuoma.Repositories;


/// <summary>
/// Controller for producing reports.
/// </summary>
public class ReportsController : Controller
{

	/// <summary>
	/// Produces contracts report.
	/// </summary>
	/// <param name="dateFrom">Starting date. Can be null.</param>
	/// <param name="dateTo">Ending date. Can be null.</param>
	/// <returns>Report view.</returns>
	[HttpGet]
	public ActionResult Contracts(int? I_DSkaiciusN, decimal? I_Etatas, int? I_Pareiga, int? I_DSkaiciusI)
	{
		var report = new SportoSalesReport.Report();

		report.I_Pareiga = I_Pareiga;
		report.I_DSkaiciusN = I_DSkaiciusN;
		report.I_DSkaiciusI = I_DSkaiciusI;
		report.I_Etatas = I_Etatas;

		report.Ataskaitos = AtaskaitaRepo.GetContracts(I_DSkaiciusN, I_Etatas, I_Pareiga, I_DSkaiciusI);

		foreach (var item in report.Ataskaitos)
		{
			item.DarbuotojaiParduotuveje = report.Ataskaitos.Where(t => t.ID == item.ID).Sum(t => t.BendrasPareiguSkaicius);
			report.BendrasDarbuotojuSkaicius += item.BendrasPareiguSkaicius;
		}
		PopulateSelection(report);

		return View(report);
	}
	public void PopulateSelection(SportoSalesReport.Report ataskaita)
	{
		var busenos = AtaskaitaRepo.ListPareigos();

		ataskaita.Pareigos = busenos.Select(it => {
			return new SelectListItem()
			{
				Value = Convert.ToString(it.Id),
				Text = it.Pavadinimas
			};
		}).ToList();
	}

}
