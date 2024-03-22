using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Repository.Model;
using Repository.Services;
using Repository.Services.IServices;

namespace WebHTL.Pages.Profile
{
    public class CheckoutModel : PageModel
    {
        
        public IActionResult OnGet(string items)
        {
          
            return Page();
        }
/*
        public IActionResult OnPostAsync()
        {

            // Process the payment based on the selected method
            if (Transaction.PaymentMethod == "Bank")
            {
                // Process bank transfer
            }
            else if (Transaction.PaymentMethod == "Momo")
            {
                // Process Momo payment
            }

            // Redirect to a confirmation page or display a success message
            return RedirectToPage("/PaymentConfirmation");
        }*/
    }
}
