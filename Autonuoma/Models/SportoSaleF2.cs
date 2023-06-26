namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSaleF2;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSaleF2.ParduotuveF2CE;


/// <summary>
/// 'Product' in list form.
/// </summary>
public class ParduotuveF2L
{
	[DisplayName("Id")]
	public int id_Product { get; set; }

	[DisplayName("Pavadinimas")]
	[Required]
	public string Pavadinimas { get; set; }

	[DisplayName("Adresas")]
	[Required]
	public string Adresas { get; set; }

	[DisplayName("Patalpų dydis")]
	[Required]
	public double Dydis { get; set; }
}


/// <summary>
/// 'Product' in create and edit forms.
/// </summary>
public class ParduotuveF2CE
{
	/// <summary>
	/// Entity data.
	/// </summary>
	public class ParduotuveF2M
	{
		[DisplayName("Pavadinimas")]
		[Required]
		public string Pavadinimas { get; set; }

		[DisplayName("Adresas")]
		[Required]
		public string Adresas { get; set; }

		[DisplayName("Patalpų dydis")]
		[Required]
		public double Dydis { get; set; }

		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Miestas")]
		[Required]
		public int fk_Miestasid_Miestas { get; set; }

	}

	/// <summary>
	/// Representation of 'Review' entity in 'Sutartis' edit form.
	/// </summary>
	public class DarbuotojasM
	{
		public int InListId { get; set; }

		[DisplayName("Vardas")]
		[Required]
		public string Vardas { get; set; }

		[DisplayName("Pavardė")]
		[Required]
		public string Pavarde { get; set; }

		[DisplayName("Asmens kodas")]
		[Required]
		public string Asmens_kodas { get; set; }

		[DisplayName("Etatas")]
		[Required]
		public decimal Etatas { get; set; }

		[DisplayName("Pareigos")]
		[Required]
		public int fk_PAREIGAid_PAREIGA { get; set; }

		[DisplayName("Parduotuvę")]
		[Required]
		public int fk_SPORTOSALEid_SPORTOSALE { get; set; }


	}

	/// <summary>
	/// Select lists for making drop downs for choosing values of entity fields.
	/// </summary>
	public class ListsM
	{

		public IList<SelectListItem> Pareigos { get; set; }
		public IList<SelectListItem> Miestas { get; set; }
	}


	/// <summary>
	/// Product.
	/// </summary>
	public ParduotuveF2M Parduotuve { get; set; } = new ParduotuveF2M();


	/// <summary>
	/// Related 'Review' records.
	/// </summary>
	public IList<DarbuotojasM> Darbuotojai { get; set; } = new List<DarbuotojasM>();

	/// <summary>
	/// Lists for drop down controls.
	/// </summary>
	public ListsM Lists { get; set; } = new ListsM();
}
