namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSalesReport;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


/// <summary>
/// View model for single contract in a report.
/// </summary>
public class Ataskaita
{
	public int ID { get; set; }

	[DisplayName("Sporto Sale")]
	public string Pavadinimas { get; set; }
	[DisplayName("Miestas")]
	public string Miestas { get; set; }
	[DisplayName("Pareigos")]
	public string Pareigos { get; set; }

	[DisplayName("Pareigu sk")]
	public int BendrasPareiguSkaicius { get; set; }

	[DisplayName("Vidutinis etatas")]
	public decimal VidutinisPareigosEtatas { get; set; }
	
	[DisplayName("Maziausias etatas")]
	public decimal MaziausiasPareigosEtatas { get; set; }
	[DisplayName("Didziausias etatas")]
	public decimal DidziausiasPareigosEtatas { get; set; }
	
	public int DarbuotojaiParduotuveje { get; set; }

	public string tekstas = " ";
	public string tekstas2 = "Darbuotoju sk. sporto saleje:";

}

/// <summary>
/// View model for whole report.
/// </summary>
public class Report
{

	public int? I_Pareiga { get; set; }
	public int? I_DSkaiciusN { get; set; }
	public int? I_DSkaiciusI { get; set; }
	public decimal? I_Etatas { get; set; }
	public List<Ataskaita> Ataskaitos { get; set; }
	public List<SelectListItem> Pareigos { get; set; }
	public int BendrasDarbuotojuSkaicius { get; set; }

}
public class Pareiga
{
	public int Id { get; set; }
	public string Pavadinimas { get; set; }
}
