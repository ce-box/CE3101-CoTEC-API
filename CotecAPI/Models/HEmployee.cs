/* ----------------------------------------------
 * File: HEmployee.cs
 * Dev by: @estalvgs1999
 * Project: CoTEC API
 * version: 1.0
 * last edited by: @estalvgs1999 [11/06/2020]
 *
 * Description: Class that represents a worker of
 * a hospital center, these are in charge of
 * patient management. They can also generate
 * reports.
 *
 * TEC 2020 | CE3101 - Bases de Datos
 * --------------------------------------------*/

namespace CotecAPI.Models
{
    public class HEmployee : User
    {
        string HospitalName { set; get;}
        string Job { set; get; }
    }
}