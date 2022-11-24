using FakeData_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeData_CodeFirst.ViewModels
{
    public class HomePageVM
    {
        public List<Kisiler> Kisiler { get; set; }
        public List<Adresler> Adresler { get; set; }

    }
}