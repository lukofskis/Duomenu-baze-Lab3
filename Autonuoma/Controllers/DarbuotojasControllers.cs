﻿namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;


/// <summary>
/// Controller for working with 'Darbuotojas' entity.
/// </summary>
public class DarbuotojasControllers : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		return View(DarbuotojasRepo.List());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in browser.
	/// </summary>
	/// <returns>Creation form view.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var darbuotojas = new Darbuotojas();
		return View(darbuotojas);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="darbuotojas">Entity model filled with latest data.</param>
	/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(Darbuotojas darbuotojas)
	{
		//do not allow creation of entity with 'asmensKodas' field matching existing one
		var match = DarbuotojasRepo.Find(darbuotojas.Asmens_kodas);

		if (match != null)
			ModelState.AddModelError("asmensKodas", "Field value already exists in database.");

		//form field validation passed?
		if (ModelState.IsValid)
		{
			DarbuotojasRepo.Insert(darbuotojas);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}

		//form field validation failed, go back to the form
		return View(darbuotojas);
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(string id)
	{
		return View(DarbuotojasRepo.Find(id));
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>		
	/// <param name="darbuotojas">Entity model filled with latest data.</param>
	/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Edit(string id, Darbuotojas darbuotojas)
	{
		//form field validation passed?
		if (ModelState.IsValid)
		{
			DarbuotojasRepo.Update(darbuotojas);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}

		//form field validation failed, go back to the form
		return View(darbuotojas);
	}

	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(string id)
	{
		var darbuotojas = DarbuotojasRepo.Find(id);
		return View(darbuotojas);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(string id)
	{
		//try deleting, this will fail if foreign key constraint fails
		try
		{
			DarbuotojasRepo.Delete(id);

			//deletion success, redired to list form
			return RedirectToAction("Index");
		}
		//entity in use, deletion not permitted
		catch (MySql.Data.MySqlClient.MySqlException)
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;

			var darbuotojas = DarbuotojasRepo.Find(id);
			return View("Delete", darbuotojas);
		}
	}
}
