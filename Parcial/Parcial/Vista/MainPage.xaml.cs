using Parcial.Model;
using Parcial.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Parcial
{
    public partial class MainPage : ContentPage
    {
        Persona persona = null;
        public MainPage()
        {
            InitializeComponent();
        }
        private async void BuscarUno(object sender, EventArgs e)
        {
            persona = await App.BaseDatos.BuscarUno(Convert.ToInt32(id.Text));
            
            if (persona == null)
            {
                await DisplayAlert("Buscar", "La persona que intenta buscar no se encuentra en la base de datos, por favor ingrese nuevamente la información", "OK");
                Limpiar();
            }
            else
            {
                cedula.Text = persona.Cedula;
                nombre.Text = persona.Nombre;
                apellido.Text = persona.Apellido;
                celular.Text = persona.Celular;
                email.Text = persona.Email;
            }
            
            
        }
        private async void Insertar(object sender, EventArgs e)
        {
            var idpersona = id.Text;
            var nombres = nombre.Text;
            var apellidos = apellido.Text;
            var celu = celular.Text;
            var ced = cedula.Text;
            var correo = email.Text;

            Persona persona = new Persona
            {
                ID = Convert.ToInt32(idpersona),
                Nombre = nombres,
                Apellido = apellidos,
                Cedula = ced,
                Celular = celu,
                Email = correo
       
            };

            var resultado = await App.BaseDatos.GuardarPersona(persona);
            
            if (resultado > 0)
            {
                await  DisplayAlert("Mensaje", "Usuario insertado/actualizado", "Ok");
            }
            else
            {
                await DisplayAlert("Mensaje", "No se registro usuario", "Ok");
            }

            Limpiar();
        }
        private async void Eliminar(object sender, EventArgs e)
        {
            var personaEliminada = await App.BaseDatos.EliminarPersona(persona);
            
            if (personaEliminada > 0)
            {
                await DisplayAlert("Eliminar", "Persona eliminada correctamente", "Ok");

            }
            else
            {
                await DisplayAlert("Eliminar", "La persona no fue eliminada correctamente", "Ok");
            }

            Limpiar();
        }   
        private async void VerTodos(object sender, EventArgs e)
        {
            var lista = await App.BaseDatos.GetPersonas();

            await Navigation.PushAsync(new Todos(lista));


        }
        private void Limpiar()
        {
            id.Text = String.Empty;
            nombre.Text = String.Empty;
            apellido.Text = String.Empty;
            celular.Text = String.Empty;
            cedula.Text = String.Empty;
            email.Text = String.Empty;
        }

        private void fecha_DateSelected(object sender, DateChangedEventArgs e)
        {

        }
    }
}
