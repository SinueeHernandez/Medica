using DayPilot.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Events.Calendar;
namespace Medica.Models
{
    public class Dpc : DayPilotCalendar
    {
        
        protected override void OnInit(InitArgs e)
        {
            var db = new MedicaContext();
            Events = from ev in db.Consulta select ev;

            DataIdField = "ConsultaId";
            DataTextField = "Sintomas";
            DataStartField = "Fecha";
            DataEndField = "FechaFin";

            Update();
        }
    }
}