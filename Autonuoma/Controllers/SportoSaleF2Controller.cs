namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSaleF2;
using System.Security.Policy;


/// <summary>
/// Controller for working with 'Parduotuve' entity. Implementation of F2 version.
/// </summary>
public class SportoSaleF2Controller : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		return View(SportoSaleF2Repo.ListParduotuves());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in a browser.
	/// </summary>
	/// <returns>Entity creation form.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var pardCE = new ParduotuveF2CE();

		//pardCE.Parduotuve.fk_Fileid_File = 1;

		PopulateLists(pardCE);

		return View(pardCE);
	}


	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="pardCE">Entity view model filled with latest data.</param>
	/// <returns>Returns creation from view or redirets back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(int? save, int? add, int? remove, ParduotuveF2CE pardCE)
	{
		
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if (add != null)
		{
			//add entry for the new record
			var up =
			  new ParduotuveF2CE.DarbuotojasM
			  {
				  InListId =
				  pardCE.Darbuotojai.Count > 0 ? pardCE.Darbuotojai.Max(it => it.InListId) + 1 : 0,

				  fk_PAREIGAid_PAREIGA = 1,
				  Vardas = "",
				  Pavarde = "",
				  Asmens_kodas = "",
				  Etatas = 1
			  };
			


			pardCE.Darbuotojai.Add(up);
			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(pardCE);
			return View(pardCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if (remove != null)
		{
			if(pardCE.Darbuotojai.Count <= 1) {
				ViewData["0people"] = true;
				return View("Delete", pardCE);
			}
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			pardCE.Darbuotojai =
			  pardCE
				.Darbuotojai
				.Where(it => it.InListId != remove.Value)
				.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(pardCE);
			return View(pardCE);
		}

		//save of the form data was requested?
		if (save != null)
		{
			for (var i = 0; i < pardCE.Darbuotojai.Count - 1; i++)
			{
				var refUp = pardCE.Darbuotojai[i];

				for (var j = i + 1; j < pardCE.Darbuotojai.Count; j++)
				{
					var testUp = pardCE.Darbuotojai[j];

					if (testUp.Asmens_kodas == refUp.Asmens_kodas)
					{
						ViewData["sameID"] = true;
						return View("Delete", pardCE);
					}
				}
			}


			if (pardCE.Darbuotojai.Count == 0)
			{
				ViewData["emptyStore"] = true;
				return View("Delete", pardCE);
			}

			//form field validation passed?
			if (ModelState.IsValid)
			{
				//create new 'Sutartis'
				pardCE.Parduotuve.Id = SportoSaleF2Repo.InsertParduotuve(pardCE);

				//create new 'UzsakytosPaslaugos' records
				foreach (var upVm in pardCE.Darbuotojai)
					SportoSaleF2Repo.InsertDarbuotojai(pardCE.Parduotuve.Id, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{

				PopulateLists(pardCE);
				return View(pardCE);
			}
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(int id)
	{
		var pardCE = SportoSaleF2Repo.FindParduotuvesCE(id);

		pardCE.Darbuotojai = SportoSaleF2Repo.ListDarbuotojai(id);
		PopulateLists(pardCE);

		return View(pardCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="pardCE">Entity view model filled with latest data.</param>
	/// <returns>Returns editing from view or redired back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Edit(int id, int? save, int? add, int? remove, ParduotuveF2CE pardCE)
	{
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if (add != null)
		{
			//add entry for the new record
			var up =
			  new ParduotuveF2CE.DarbuotojasM
			  {
				  InListId =
				  pardCE.Darbuotojai.Count > 0 ?
				  pardCE.Darbuotojai.Max(it => it.InListId) + 1 :
				  0,

				  fk_PAREIGAid_PAREIGA = 1,
				  Vardas = "",
				  Pavarde = "",
				  Asmens_kodas = "",
				  Etatas = 1
			  };

			pardCE.Darbuotojai.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();
			//go back to the form
			PopulateLists(pardCE);
			return View(pardCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if (remove != null)
		{
			if (pardCE.Darbuotojai.Count <= 1)
			{
				ViewData["0people"] = true;
				return View("Delete", pardCE);
			}
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			pardCE.Darbuotojai =
			  pardCE
				.Darbuotojai
				.Where(it => it.InListId != remove.Value)
				.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(pardCE);
			return View(pardCE);
		}

		//save of the form data was requested?
		if (save != null)
		{
			for (var i = 0; i < pardCE.Darbuotojai.Count - 1; i++)
			{
				var refUp = pardCE.Darbuotojai[i];

				for (var j = i + 1; j < pardCE.Darbuotojai.Count; j++)
				{
					var testUp = pardCE.Darbuotojai[j];

					if (testUp.Asmens_kodas == refUp.Asmens_kodas)
					{
						ViewData["sameID"] = true;
						return View("Delete", pardCE);
					}			
				}
			}

			if (pardCE.Darbuotojai.Count == 0)
			{
				ViewData["emptyStore"] = true;
				return View("Delete", pardCE);
			}

			if (ModelState.IsValid)
			{
				SportoSaleF2Repo.UpdateParduotuve(pardCE);
				SportoSaleF2Repo.DeleteDarbuotojaiParduotuveje(pardCE.Parduotuve.Id);
				foreach (var upVm in pardCE.Darbuotojai)
					SportoSaleF2Repo.InsertDarbuotojai(pardCE.Parduotuve.Id, upVm);

				return RedirectToAction("Index");
			}
			else
			{
				PopulateLists(pardCE);
				return View(pardCE);
			}
		}
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when deletion form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(int id)
	{
		var pardCE = SportoSaleF2Repo.FindParduotuvesCE(id);
		return View(pardCE);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//load 'Sutartis'
		var sutCE = SportoSaleF2Repo.FindParduotuvesCE(id);

		//'Sutartis' is in the state where deletion is permitted?
		//if (true) //sutCE.Parduotuve.FkBusena == 1 || sutCE.Sutartis.FkBusena == 3) !!!
		{
			//delete the entity
			SportoSaleF2Repo.DeleteDarbuotojaiParduotuveje(id);
			SportoSaleF2Repo.DeleteParduotuve(id);

			//redired to list form
			return RedirectToAction("Index");
		}
	}

	/// <summary>
	/// Populates select lists used to render drop down controls.
	/// </summary>
	/// <param name="pardCE">'Parduotuve' view model to append to.</param>
	private void PopulateLists(ParduotuveF2CE pardCE)
	{
		//load entities for the select lists
		var miest = MiestasRepo.List();
		var pare = PareigaRepo.List();

		//build select lists
		pardCE.Lists.Miestas =
		  miest
			.Select(it =>
			{
				return
			  new SelectListItem
				{
					Value = Convert.ToString(it.Id),
					Text = $"{it.Pavadinimas}"
				};
			})
			.ToList();

		pardCE.Lists.Pareigos =
		  pare
			.Select(it =>
			{
				return
			  new SelectListItem
				{
					Value = Convert.ToString(it.id_Pareiga),
					Text = $"{it.Pavadinimas}"
				};
			})
			.ToList();
	}
}

