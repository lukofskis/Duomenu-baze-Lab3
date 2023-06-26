namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Pareiga' entity.
/// </summary>
public class Pareiga
{
	[DisplayName("Id")]
	public int id_Pareiga { get; set; }

	[DisplayName("Pavadinimas")]
	[Required]
	public string Pavadinimas { get; set; }

	[DisplayName("Valandinis")]
	[Required]
	public decimal Valandinis { get; set; }

}
