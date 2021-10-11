using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgendamientoCitas.App.Dominio;
using AgendamientoCitas.App.Persistencia.AppRepositorios;

namespace AgendamientoCitas.App.Frontend.Pages.Pacientes
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        public Paciente paciente {get; set;}
        public EditModel(IRepositorioPaciente repoPaciente)
        {
            _repoPaciente = repoPaciente;
        }
        public void OnGet(int id) //inicializar paciente
        {
            paciente = _repoPaciente.GetPaciente(id);
            if(paciente==null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost (Paciente paciente)
        {
            _repoPaciente.UpdatePaciente(paciente);
            return RedirectToPage("Index");
        }
    } 
}
