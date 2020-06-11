/* ----------------------------------------------
 * File: User.cs
 * Dev by: @estalvgs1999
 * Project: CoTEC API
 * version: 1.0
 * last edited by: @estalvgs1999 [10/06/2020]
 *
 * Description: Class that represents the general
 * abstraction of a user. This class can be
 * inherited by specific users.
 *
 * TEC 2020 | CE3101 - Bases de Datos
 * --------------------------------------------*/

namespace CotecAPI.Models
{
    public class User
    {

        int Id { set; get; } // Numeric identifier of users
        string Name { set; get; }
        string LastName { set; get; }
        string Country { set; get; }
        string Email { set; get; }
        string Password { set; get; }

    }
}