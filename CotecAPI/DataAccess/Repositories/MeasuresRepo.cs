using System;
using System.Collections.Generic;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace CotecAPI.DataAccess.Repositories
{
    public class MeasuresRepo
    {
         private readonly CotecContext _context;

        // Inject the Data Base Context
        public MeasuresRepo(CotecContext context)
        {
            _context = context;
        }

        /* -------------------------------------------
                           READ METHODS 
           -------------------------------------------*/

        public IEnumerable<MeasureView> GetSanitaryMeasures([FromQuery] string CountryCode)
        {   
            // TODO: Connect w/DB Context
            // Mock Inf@
            var measures = new List<MeasureView>(){
                new MeasureView(){
                    Name = "Uso Obligatorio de Mascarilla",
                    Description = "Ahora todos usando mascarilla perros",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                },
                new MeasureView(){
                    Name = "Uso Obligatorio de Mascarilla",
                    Description = "Ahora todos usando mascarilla perros",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                },
                new MeasureView(){
                    Name = "Uso Obligatorio de Mascarilla",
                    Description = "Ahora todos usando mascarilla perros",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                },
                new MeasureView(){
                    Name = "Uso Obligatorio de Mascarilla",
                    Description = "Ahora todos usando mascarilla perros",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                },
                new MeasureView(){
                    Name = "Uso Obligatorio de Mascarilla",
                    Description = "Ahora todos usando mascarilla perros",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                }

            };

            return measures;
        }

        public IEnumerable<MeasureView> GetContainmentMeasures([FromQuery] string CountryCode)
        {   
            // TODO: Connect w/DB Context
            // Mock Inf@
            var measures = new List<MeasureView>(){
                new MeasureView(){
                    Name = "Fronteras Cerradas",
                    Description = "Se cierran las fronteras",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                },
                new MeasureView(){
                    Name = "Fronteras Cerradas",
                    Description = "Se cierran las fronteras",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                },
                new MeasureView(){
                    Name = "Fronteras Cerradas",
                    Description = "Se cierran las fronteras",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                },
                new MeasureView(){
                    Name = "Fronteras Cerradas",
                    Description = "Se cierran las fronteras",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                },
                new MeasureView(){
                    Name = "Fronteras Cerradas",
                    Description = "Se cierran las fronteras",
                    StartDate = DateTime.Parse("2020/04/02"),
                    EndDate = DateTime.Parse("2020/12/31"),
                    Status = "Active"
                }

            };

            return measures;
        }

        /* -------------------------------------------
                        CREATE METHODS 
           -------------------------------------------*/

        public void CreateSanitaryMeasure(SanitaryMeasure sm)
        {
            // TODO: Connect w/DB Context
        }

        public void CreateContainmentMeasure(ContainmentMeasure cm)
        {
            // TODO: Connect w/DB Context
        }

        public void AssingSanitaryMeasure(CountrySanitaryMeasures csm)
        {
            // TODO: Connect w/DB Context
        }

        public void AssingContainmentMeasure(CountryContainmentMeasures ccm)
        {
            // TODO: Connect w/DB Context
        }

        /* -------------------------------------------
                        DELETE METHODS 
           -------------------------------------------*/
        
        public void DeleteSanitaryMeasure(CountrySanitaryMeasures csm)
        {
            // TODO: Connect w/DB Context
        }

        public void DeleteContainmentMeasure(CountryContainmentMeasures ccm)
        {
            // TODO: Connect w/DB Context
        }

        /* -------------------------------------------
                        UPDATE METHODS 
           -------------------------------------------*/
        
        public void UpdateSanitaryMeasure(CountrySanitaryMeasures csm)
        {
            // TODO: Connect w/DB Context
        }

        public void UpdateContainmentMeasure(CountryContainmentMeasures ccm)
        {
            // TODO: Connect w/DB Context
        }

        /**         
         * Save the changes made to the database
         */
        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }

    }
}