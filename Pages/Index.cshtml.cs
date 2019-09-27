using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.ApplicationInsights;

namespace VitecProjekt.Pages
{
    public class IndexModel : PageModel
    {
        TelemetryClient telemetry;
        public IndexModel(TelemetryClient telemetry)
        {
            this.telemetry = telemetry;
        }
        public void OnGet()
        {
            
            telemetry.TrackEvent("Main page loaded");
            
        }
    }
}
