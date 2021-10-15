using System;
using System.Collections.Generic;
using System.Linq;
using AgendamientoCitas.App.Dominio;

namespace AgendamientoCitas.App.Persistencia
{
    public class RepositorioPaciente: IRepositorioPaciente
    {
        private readonly AppContext _appContext = new AppContext();
        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
          {
            var pacienteAdicionado= _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges(); //Se deben guardar los cambios
            return pacienteAdicionado.Entity; 
          }
        void IRepositorioPaciente.DeletePaciente(int idPaciente)
          {
            var pacienteEncontrado= _appContext.Pacientes.FirstOrDefault(p =>p.Id==idPaciente);//p es el primero que encuentra. Recorre todos los elementos de la tabla
            if(pacienteEncontrado==null)
              return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();//Se deben guardar los cambios
          }
        IEnumerable <Paciente> IRepositorioPaciente.GetAllPacientes()
          {
            return _appContext.Pacientes;
             
          }
        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
          {
           return _appContext.Pacientes.FirstOrDefault(p =>p.Id==idPaciente);//retorna lo que encuentra
          }
        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
          {
           var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p =>p.Id==paciente.Id);
           //No se busca el idPacienteEncontrado, se busca la pacienteEncontrado.Id
           if(pacienteEncontrado!=null)
           {
                pacienteEncontrado.TipoPaciente=paciente.TipoPaciente;
                //pacienteEncontrado.IdCita=paciente.IdCita;
                pacienteEncontrado.Nombre=paciente.Nombre;
                pacienteEncontrado.Apellidos=paciente.Apellidos;
                pacienteEncontrado.Identificacion=paciente.Identificacion;
                pacienteEncontrado.Edad=paciente.Edad;
                pacienteEncontrado.Ciudad=paciente.Ciudad;
                pacienteEncontrado.Telefono=paciente.Telefono;
                pacienteEncontrado.Email=paciente.Email;
                pacienteEncontrado.Genero=paciente.Genero;
                
                _appContext.SaveChanges();        
           }
             return pacienteEncontrado; //retorna el prestadorDeServicioEncontrado encontrado
            
          }
    }
}