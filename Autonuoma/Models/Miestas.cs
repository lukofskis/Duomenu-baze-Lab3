namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class Miestas
{
	[DisplayName("Pavadinimas")]
	[Required]
	public string Pavadinimas { get; set; }

	[DisplayName("Id")]
	public int Id { get; set; }

}
