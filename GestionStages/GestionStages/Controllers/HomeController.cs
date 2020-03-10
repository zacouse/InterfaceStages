﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionStages.Models;
using System.Data.SqlClient;

namespace GestionStages.Controllers
{
    public class HomeController : Controller
    {
        public static SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=GestionStage;Integrated Security=True");
        private SqlDataReader dr;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            List<Etudiant> lesEtudiants = new List<Etudiant>();
            SqlCommand sql = new SqlCommand();
            conn.Open();
            sql.Connection = HomeController.conn;
            sql.CommandText = "EXEC pGetAllActiveEtudiant";
            dr = sql.ExecuteReader();
            while (dr.Read())
            {
                Etudiant etudiant = new Etudiant();
                etudiant.IDEtudiant = (int)dr.GetValue(0);
                etudiant.Programme = (string)dr.GetValue(1);
                etudiant.NoDA = (int)dr.GetValue(2);
                etudiant.Prenom = (string)dr.GetValue(3);
                etudiant.Nom = (string)dr.GetValue(4);
                etudiant.Email = (string)dr.GetValue(5);
                lesEtudiants.Add(etudiant);
            }
            conn.Close();
            ViewBag.lesEtudiants = lesEtudiants;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
